# Dozaj Raporlama Sistemi

Bu proje, fabrika ortamındaki üretim hatlarının, batch (parti) bazlı üretimlerin ve hammadde dozajlama işlemlerinin detaylı analizini sunan, **C# WPF** ve **MVVM** mimarisi kullanılarak geliştirilmiş profesyonel bir masaüstü raporlama uygulamasıdır.

##  Öne Çıkan Özellikler

- **Gelişmiş MVVM Mimarisi:** Spagetti koddan uzak, tamamen `CommunityToolkit.Mvvm` ile yönetilen, sürdürülebilir ve test edilebilir altyapı.
- **Master-Detail Veri Görselleştirme:** Üretim özetleri (Master) ve o üretime ait kantar/malzeme bazlı dozaj detaylarının (Detail) senkronize ve anlık gösterimi.
- **Kümülatif Analiz (Total Report):** Belirlenen tarih aralığında, kantar (Scale No) bazlı toplam reçete, toplam dozaj ve sapma miktarlarının tek ekranda gruplanarak analizi.
- **Dinamik Zaman ve Hedef Filtreleme:** "Bugün", "Son 1 Hafta", "Son 1 Ay" veya "Özel Tarih Aralığı" gibi hızlı filtreleme seçenekleri ve üretim varış noktasına (Stock Area / Export Zone) göre anlık sorgulama.
- **Endüstriyel UI/UX Tasarımı:** Kullanıcıyı yormayan, yüksek kontrastlı ve okunabilir modern SCADA tema konsepti.

##  Kullanılan Teknolojiler

- **Dil:** C# (.NET 6 / 8)
- **Arayüz (UI):** WPF (Windows Presentation Foundation)
- **Mimari:** MVVM (Model-View-ViewModel)
- **ORM / Veritabanı:** Entity Framework Core
- **Paketler:** `CommunityToolkit.Mvvm`, `Microsoft.EntityFrameworkCore`

##  Proje Mimarisi (Klasör Yapısı)

Proje, kurumsal standartlara uygun olarak katmanlı bir şekilde tasarlanmıştır:
```text
📁 Data_Report
 ┣ 📂 Data         # AppDbContext ve veritabanı konfigürasyonları
 ┣ 📂 Models       # ProductionMaster, ProductionDetail, SummaryReportItem
 ┣ 📂 ViewModels   # İş mantığı, LINQ sorguları ve UI State yönetimi
 ┣ 📂 Views        # HomeWindow, MainWindow (Rapor), TotalReportWindow XAML dosyaları
 ┗ 📄 App.xaml     # Uygulama başlangıç noktası
```

##  Ekran Görüntüleri

### 1. Ana Dashboard
<img width="886" height="593" alt="Ekran görüntüsü 2026-04-30 143047" src="https://github.com/user-attachments/assets/668a6df9-1f8b-41fe-b1b1-446d7dc525f5" />


### 2. Detaylı Üretim Raporu (Master/Detail)
<img width="1386" height="793" alt="Ekran görüntüsü 2026-04-30 143113" src="https://github.com/user-attachments/assets/19859552-1ca1-4238-94f8-47bf6e630f8e" />


### 3. Genel Özet Raporu (Total Report)
<img width="986" height="693" alt="Ekran görüntüsü 2026-04-30 143136" src="https://github.com/user-attachments/assets/5d3d0568-e299-43bb-b8b0-4b3636970846" />


##  Kurulum ve Çalıştırma

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

1. Projeyi klonlayın:
   ```bash
   git clone [https://github.com/](https://github.com/)<KULLANICI_ADIN>/Data_Report.git
   ```
2. Visual Studio ile `Data_Report.sln` dosyasını açın.
3. NuGet paketlerini geri yükleyin (Restore NuGet Packages).
4. Veritabanı bağlantı cümlenizi `AppDbContext.cs` içinden kendi sisteminize göre güncelleyin.
5. **F5** veya **Start** butonuna basarak projeyi derleyip çalıştırın.

##  Katkıda Bulunma

Bu proje geliştirmeye açıktır. Katkıda bulunmak isterseniz lütfen bir PR (Pull Request) açmaktan çekinmeyin.
