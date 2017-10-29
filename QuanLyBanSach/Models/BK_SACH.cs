namespace QuanLyBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BK_SACH
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string masach { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string tensach { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(8)]
        public string matheloai { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dongiaban { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int luotmua { get; set; }

        [Key]
        [Column(Order = 5)]
        public double khuyenmai { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(30)]
        public string anhbia { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool tinhtrang { get; set; }

        [Key]
        [Column(Order = 8)]
        public string mota { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(25)]
        public string nhaxuatban { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(20)]
        public string tacgia { get; set; }

        [Key]
        [Column(Order = 11, TypeName = "date")]
        public DateTime ngayxuatban { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int soluongton { get; set; }
    }
}
