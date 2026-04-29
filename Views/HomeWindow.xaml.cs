using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Data_Report.Views
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }
        private void BtnOpenReport_Click(object sender, RoutedEventArgs e)
        {
            MainWindow reportScreen= new MainWindow();
            //Rapor ekranını gosterme
            reportScreen.Show();
        }
        private void BtnOpenTotalReport_Click(object sender, RoutedEventArgs e)
        {
            TotalReportWindow totalReport = new TotalReportWindow();
            totalReport.Show();
        }
    }
}
