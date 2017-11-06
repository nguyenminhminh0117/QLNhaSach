namespace QLBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAP")]
    public partial class PHIEUNHAP
    {
        [Key]
        [StringLength(8)]
        public string mapn { get; set; }

        [Required]
        [StringLength(8)]
        public string manv { get; set; }

        [Required]
        [StringLength(8)]
        public string mancc { get; set; }

        public int soluongnhap { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaylapphieu { get; set; }

        public int tongtiennhap { get; set; }
    }
}
