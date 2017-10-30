namespace QLBanSach.Models
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

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int soluong { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int gianhap { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int thanhtien { get; set; }

        public virtual PHIEUNHAP PHIEUNHAP { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
