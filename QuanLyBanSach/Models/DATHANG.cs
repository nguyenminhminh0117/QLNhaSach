namespace QuanLyBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DATHANG")]
    public partial class DATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DATHANG()
        {
            CT_DATHANG = new HashSet<CT_DATHANG>();
        }

        [Key]
        [StringLength(8)]
        public string madathang { get; set; }

        [Required]
        [StringLength(8)]
        public string makh { get; set; }

        [Required]
        [StringLength(20)]
        public string sdt { get; set; }

        [Required]
        [StringLength(100)]
        public string diachi { get; set; }

        public DateTime ngaydat { get; set; }

        public DateTime ngaygiao { get; set; }

        public int tongdonhang { get; set; }

        public bool tinhtrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DATHANG> CT_DATHANG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
