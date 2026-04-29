using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Data_Report.Data;
using Data_Report.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Report.ViewModels
{
    public partial class TotalReportViewModel : ObservableObject
    {
        private readonly AppDbContext _context;

        [ObservableProperty] private ObservableCollection<SummaryReportItem> reportList;

        // ==========================================
        // 1. FİLTRE DEĞİŞKENLERİ (İlk ekranla aynı)
        // ==========================================
        [ObservableProperty] private string selectedTimeRange = "Bugün";
        partial void OnSelectedTimeRangeChanged(string value)
        {
            UpdateDatesBasedOnTimeRange();
            LoadSummaryData();
        }

        [ObservableProperty] private DateTime startDate = DateTime.Today;
        partial void OnStartDateChanged(DateTime value) => LoadSummaryData();

        [ObservableProperty] private DateTime endDate = DateTime.Now;
        partial void OnEndDateChanged(DateTime value) => LoadSummaryData();

        [ObservableProperty] private string selectedDestination = "Hepsi";
        partial void OnSelectedDestinationChanged(string value) => LoadSummaryData();

        // ==========================================
        // 2. ALT TOPLAM DEĞİŞKENLERİ
        // ==========================================
        [ObservableProperty] private double grandTotalRecipe;
        [ObservableProperty] private double grandTotalDosed;
        [ObservableProperty] private double grandTotalDeviation;

        public TotalReportViewModel()
        {
            _context = new AppDbContext();
            ReportList = new ObservableCollection<SummaryReportItem>();

            // Açılışta bugünün tarihlerini ayarla ve veriyi çek
            UpdateDatesBasedOnTimeRange();
            LoadSummaryData();
        }

        private void UpdateDatesBasedOnTimeRange()
        {
            DateTime now = DateTime.Now;
            switch (SelectedTimeRange)
            {
                case "Bugün":
                    StartDate = DateTime.Today; // Gece 00:00
                    EndDate = now;
                    break;
                case "Son 1 Hafta":
                    StartDate = now.AddDays(-7);
                    EndDate = now;
                    break;
                case "Son 1 Ay":
                    StartDate = now.AddMonths(-1);
                    EndDate = now;
                    break;
            }
        }

        public void LoadSummaryData()
        {
            if (_context == null) return;

            // 1. Sorguyu oluştur (Master tablosunu da dahil et çünkü Destination ve Date orada)
            var query = _context.ProductionDetails.Include(d => d.Master).AsQueryable();

            // 2. Tarih Filtresi
            query = query.Where(d => d.Master.Date >= StartDate && d.Master.Date <= EndDate);

            // 3. Varış Noktası (Destination) Filtresi
            if (SelectedDestination != "Hepsi")
            {
                query = query.Where(d => d.Master.Destination == SelectedDestination);
            }

            // 4. Verileri SQL'den çek ve Kantar Numarasına göre grupla
            var groupedData = query
                .ToList()
                .GroupBy(d => d.ScaleNo)
                .Select(g => new SummaryReportItem
                {
                    ScaleNo = (byte)g.Key,
                    TotalRecipe = g.Sum(x => x.Recipe ?? 0),
                    TotalDosed = g.Sum(x => x.Dosed ?? 0)
                })
                .OrderBy(x => x.ScaleNo)
                .ToList();

            // 5. Listeyi arayüze bas
            ReportList.Clear();
            foreach (var item in groupedData) ReportList.Add(item);

            // 6. Genel Toplamları Hesapla
            GrandTotalRecipe = ReportList.Sum(x => x.TotalRecipe);
            GrandTotalDosed = ReportList.Sum(x => x.TotalDosed);
            GrandTotalDeviation = GrandTotalDosed - GrandTotalRecipe;
        }
    }
}