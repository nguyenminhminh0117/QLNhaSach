//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBanSach.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DATHANG()
        {
            this.CT_DATHANG = new HashSet<CT_DATHANG>();
        }
    
        public string madathang { get; set; }
        public string makh { get; set; }
        public string sdt { get; set; }
        public string diachi { get; set; }
        public System.DateTime ngaydat { get; set; }
        public System.DateTime ngaygiao { get; set; }
        public int tongdonhang { get; set; }
        public bool tinhtrang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DATHANG> CT_DATHANG { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}