using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Report.Models
{
    public class SummaryReportItem
    {
        public byte ScaleNo { get; set; }
        public double TotalRecipe { get; set; }
        public double TotalDosed { get; set; }
        public double TotalDeviation => TotalDosed - TotalRecipe;
    }
}
