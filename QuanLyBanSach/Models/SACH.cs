namespace QuanLyBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CT_DATHANG = new HashSet<CT_DATHANG>();
            CT_HOADON = new HashSet<CT_HOADON>();
            CT_PHIEUNHAP = new HashSet<CT_PHIEUNHAP>();
        }

        [Key]
        [StringLength(8)]
        [Display(Name = "Mã sách")]
        public string masach { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên sách")]
        public string tensach { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "mã thể loại")]
        public string matheloai { get; set; }
        [Display(Name = "Đơn giá bán")]
        public int dongiaban { get; set; }
        [Display(Name = "Lượt mua")]
        public int luotmua { get; set; }
        [Display(Name = "Khuyến mãi")]
        public double khuyenmai { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Ảnh bìa")]
        public string anhbia { get; set; }
        [Display(Name = "Tình trạng")]
        public bool tinhtrang { get; set; }
        [Display(Name = "Mô tả")]
        [Required]
        public string mota { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Nhà xuất bản")]
        public string nhaxuatban { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Tác giả")]
        public string tacgia { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày xuất bản")]
        public DateTime ngayxuatban { get; set; }

        [Display(Name = "Số lượng tồn")]
        public int soluongton { get; set; }

        public int delflag { get; set; }

        public DateTime? timedel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DATHANG> CT_DATHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOADON> CT_HOADON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAP> CT_PHIEUNHAP { get; set; }

        public virtual THELOAI THELOAI { get; set; }
    }
}
