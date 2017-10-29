namespace QuanLyBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_DATHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string madathang { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string masach { get; set; }

        public int soluongdat { get; set; }

        public int dongia { get; set; }

        public int thanhtien { get; set; }

        public int delflag { get; set; }

        public DateTime? timedel { get; set; }

        public virtual DATHANG DATHANG { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
