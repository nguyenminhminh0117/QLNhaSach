namespace QuanLyBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DATHANGs = new HashSet<DATHANG>();
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(8)]
        [Display(Name ="Mã khách hàng")]
        public string makh { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Tên khách hàng")]

        public string tenkh { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Địa chỉ")]

        public string diachi { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Số điện thoại")]

        public string sodienthoai { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]

        public string email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mật khẩu")]

        public string matkhaukh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATHANG> DATHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
