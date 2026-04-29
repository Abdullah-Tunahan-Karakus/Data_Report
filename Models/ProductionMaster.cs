using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Report.Models
{
    [Table("Uretim_Master")]
    public class ProductionMaster
    {
        [Key]//PRİMARY KEY
        [Column("BatchId")]
        public string BatchId { get; set; }

        [Column("ProductionUnit")]
        public string ProductionUnit { get; set; }

        [Column("Line")]
        public string Line { get; set; }

        [Column("Destination")]
        public string Destination { get; set; }

        [Column("ProductionDate")]
        public DateTime? ProductionDate { get; set; }

        //Mastere Detail İlişkisinin Kurulduğu Kısım
        public virtual ICollection<ProductionDetail> Details { get; set; }
    }
}
