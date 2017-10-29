namespace QuanLyBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOADONs = new HashSet<HOADON>();
            PHIEUNHAPs = new HashSet<PHIEUNHAP>();
        }

        [Key]
        [StringLength(8)]
        [Display(Name ="Mã nhân viên")]
        public string manv { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên nhân viên")]
        public string tennv { get; set; }

        [Display(Name = "Ngày sinh")]
        [Column(TypeName = "date")]
        public DateTime ngaysinh { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Địa chỉ")]
        public string diachi { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Số điện thoại")]
        public string sodienthoai { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mật khẩu ")]
        public string matkhaunv { get; set; }

        [Required]
        [StringLength(8)]
        //[Display(Name = "Mã quyền")]
        public string maquyen { get; set; }

        [Display(Name = "Tình trạng")]
        public bool tinhtrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        public virtual QUYEN QUYEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAPs { get; set; }
    }
}
