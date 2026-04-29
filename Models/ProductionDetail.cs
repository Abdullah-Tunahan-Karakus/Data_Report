using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Report.Models
{
    //Sınıfı SQL Üretim Detay Tablosuna Bağlama
    [Table("Uretim_Detay")]
    public class ProductionDetail
    {
        [Key]//Primary Key 
        [Column("DetailId")]
        public int DetailId { get; set; }

        [Column("BatchId")]
        public string BatchId { get; set; }

        [Column("ScaleNo")]
        public byte? ScaleNo { get; set; }

        [Column("MaterialNo")]
        public string MaterialNo { get; set; }

        [Column("MaterialName")]
        public string MaterialName { get; set; }

        [Column("Recipe")]
        public double? Recipe { get; set; }

        [Column("Dosed")]
        public double? Dosed { get; set; }

        //Ayrı Hesaplancak Sql de yok 
        [NotMapped]
        public double? Deviation => Dosed - Recipe;

        [ForeignKey("BatchId")]
        public virtual required ProductionMaster  Master { get; set; }
    }
}
