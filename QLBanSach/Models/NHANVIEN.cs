namespace QLBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [Key]
        [StringLength(8)]
        public string manv { get; set; }

        [Required]
        [StringLength(50)]
        public string tennv { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaysinh { get; set; }

        [Required]
        [StringLength(150)]
        public string diachi { get; set; }

        [Required]
        [StringLength(25)]
        public string sodienthoai { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string matkhaunv { get; set; }

        [Required]
        [StringLength(8)]
        public string maquyen { get; set; }

        public bool tinhtrang { get; set; }
    }
}
