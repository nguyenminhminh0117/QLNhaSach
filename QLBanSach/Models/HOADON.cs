namespace QLBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        [StringLength(8)]
        public string mahoadon { get; set; }

        [Required]
        [StringLength(8)]
        public string manv { get; set; }

        [Required]
        [StringLength(8)]
        public string makh { get; set; }

        public DateTime ngaylap { get; set; }

        public int tonghoadon { get; set; }
    }
}
