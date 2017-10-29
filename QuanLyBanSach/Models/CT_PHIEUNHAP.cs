namespace QuanLyBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUNHAP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string masach { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string mapn { get; set; }

        public int soluong { get; set; }

        public int gianhap { get; set; }

        public int thanhtien { get; set; }

        public virtual PHIEUNHAP PHIEUNHAP { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
