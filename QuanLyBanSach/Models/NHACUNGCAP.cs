namespace QuanLyBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACUNGCAP")]
    public partial class NHACUNGCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            PHIEUNHAPs = new HashSet<PHIEUNHAP>();
        }

        [Key]
        [StringLength(8)]
        [Display(Name = "Mã nhà cung cấp")]

        public string mancc { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Tên nhà cung cấp")]

        public string tenncc { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Địa chỉ")]

        public string diachi { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Số điện thoại")]

        public string sdtncc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAPs { get; set; }
    }
}
