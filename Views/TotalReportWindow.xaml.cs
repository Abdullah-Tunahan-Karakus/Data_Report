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
using Data_Report.ViewModels;

namespace Data_Report.Views
{
    /// <summary>
    /// Interaction logic for TotalReportWindow.xaml
    /// </summary>
    public partial class TotalReportWindow : Window
    {
        public TotalReportWindow()
        {
            InitializeComponent();
            this.DataContext = new TotalReportViewModel();
        }
    }
}
