using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Report.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;

namespace Data_Report.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<ProductionMaster> ProductionMasters { get; set; }
        public DbSet<ProductionDetail> ProductionDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQL Server Bağlantı Ayarları
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=TUNA;Database=UretimVerileri;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
