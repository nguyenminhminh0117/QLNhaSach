namespace QuanLyBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BK_CT_DATHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string madathang { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string masach { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int soluongdat { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dongia { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int thanhtien { get; set; }
    }
}
