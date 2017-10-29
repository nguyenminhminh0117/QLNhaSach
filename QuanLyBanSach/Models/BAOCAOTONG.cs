namespace QuanLyBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAOCAOTONG")]
    public partial class BAOCAOTONG
    {
        [Key]
        [Display(Name ="Ngày")]
        public DateTime ngay { get; set; }
        [Display(Name = "Tổng thu")]

        public int tongthu { get; set; }
        [Display(Name = "Tổng chi")]

        public int tongchi { get; set; }
        [Display(Name = "Chênh lệch")]

        public int chenhlech { get; set; }
        [Display(Name = "Delflag")]

        public int delflag { get; set; }
        [Display(Name = "Timedel")]

        public DateTime? timedel { get; set; }
    }
}
