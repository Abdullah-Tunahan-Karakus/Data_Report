using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Data_Report.Data;
using Data_Report.Models;
using Microsoft.IdentityModel.Abstractions;

namespace Data_Report.ViewModels
{
    public partial class MainViewMode : ObservableObject
    {
        private readonly AppDbContext _context;

        //Tablo Listeleri
        [ObservableProperty]
        private ObservableCollection<ProductionMaster> masterList;

        [ObservableProperty]
        private ObservableCollection<ProductionDetail> detailList;

        //Seçilenn Veriler ve Tetikleyiciler

        //MASTER TABLOSU BİR SATIR SEÇİLDİĞİNDE ÇALIŞIR
        [ObservableProperty]
        private ProductionMaster selectedMaster;
        partial void OnSelectedMasterChanged(ProductionMaster value)
        {
            LoadDetails();//Seçim değştiğinde detayları getir
        }
        //Filtre Değişkenleri 

        [ObservableProperty]
        private string selectedTimeRange= "Bugün";
        partial void OnSelectedTimeRangeChanged(string value)
        {
            UpdateDateBasedOnTimeRange();//Zaman aralığı değiştiğinde tarihleri güncelle
            LoadMasterData();
        }


        [ObservableProperty]
        private DateTime startDate = DateTime.Today;

        partial void OnStartDateChanged(DateTime value) => LoadMasterData();

        [ObservableProperty]
        private DateTime endDate = DateTime.Now;

        partial void OnEndDateChanged(DateTime value) => LoadMasterData();

        [ObservableProperty]
        private string selectedDestination = "Hepsi";
        partial void OnSelectedDestinationChanged(string value) => LoadMasterData();

        //Başlangıç  Metotlar   
        public MainViewMode()
        {
            _context= new AppDbContext();
            MasterList = new ObservableCollection<ProductionMaster>();
            DetailList = new ObservableCollection<ProductionDetail>();

            //Program ACILDIGINDA VERİLERİ Otamatık yukleme

            UpdateDateBasedOnTimeRange();
            LoadMasterData();
        }
        private void UpdateDateBasedOnTimeRange()
        {
            DateTime now= DateTime.Now;
            switch(SelectedTimeRange)
            {
                case "Bugün":
                    StartDate =DateTime.Today;
                    EndDate = now;
                    break;
                case "Son 1 Hafta":
                    StartDate=now.AddDays(-7);
                    EndDate = now;
                    break;
                case "Son 1 Ay":
                    StartDate = now.AddMonths(-1);
                    EndDate = now;
                    break;

            }
        }
        
        private void LoadMasterData()
        {
            if (_context == null) return;
            //1.Veritabının da tum master sorgula
            var query =_context.ProductionMasters.AsQueryable();
            //Tarih Filtresi Uygula
            query = query.Where(x => x.Date >= StartDate && x.Date <= EndDate);
            ////Destination Filtresi Uygula
            if (SelectedDestination != "Hepsi")
            {
                query = query.Where(x => x.Destination == SelectedDestination);
            }

            //Verileri Çek ve son üretim göre sırala
            var result = query.OrderByDescending(x => x.Date).ToList();


            //Arayüzde ki listeyi güncelleme
            MasterList.Clear();
            foreach(var item in result)
            {
                MasterList.Add(item);
            }
            //Master Liste Detail temizle
            DetailList.Clear();
            //En üste focuslanma
            if(MasterList.Any())
            {
                SelectedMaster=MasterList.First();
            }
            else
            {
                SelectedMaster = null;
                DetailList.Clear();
            }
        }
        private void LoadDetails()
        {
            //Eğer seçim boşsa ve veritabanı da yoksa detayı temızle
            if(SelectedMaster == null || _context == null)
            {
                DetailList.Clear();
                return;
            }
            //Seçilen BatchId ye göre detayları getir
            var details = _context.ProductionDetails
                                  .Where(d => d.BatchId == SelectedMaster.BatchId)
                                  .ToList();
            DetailList.Clear();
            foreach(var item in details)
            {
                DetailList.Add(item);
            }
        }




    }
}
