namespace QLBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [Key]
        [StringLength(8)]
        public string masach { get; set; }

        [Required]
        [StringLength(50)]
        public string tensach { get; set; }

        [Required]
        [StringLength(8)]
        public string matheloai { get; set; }

        public int dongiaban { get; set; }

        public int luotmua { get; set; }

        public double khuyenmai { get; set; }

        [Required]
        [StringLength(30)]
        public string anhbia { get; set; }

        public bool tinhtrang { get; set; }

        [Required]
        public string mota { get; set; }

        [Required]
        [StringLength(25)]
        public string nhaxuatban { get; set; }

        [Required]
        [StringLength(20)]
        public string tacgia { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayxuatban { get; set; }

        public int soluongton { get; set; }

        public int delflag { get; set; }

        public DateTime? timedel { get; set; }
    }
}
