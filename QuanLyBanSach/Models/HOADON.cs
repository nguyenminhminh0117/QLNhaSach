namespace QuanLyBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CT_HOADON = new HashSet<CT_HOADON>();
        }

        [Key]
        [StringLength(8)]
        [Display(Name = "Mã hóa đơn")]

        public string mahoadon { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "Mã nhân viên")]

        public string manv { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "Mã khách hàng")]

        public string makh { get; set; }
        [Display(Name = "Ngày lập")]

        public DateTime ngaylap { get; set; }
        [Display(Name = "Tổng hóa đơn")]

        public int tonghoadon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOADON> CT_HOADON { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
