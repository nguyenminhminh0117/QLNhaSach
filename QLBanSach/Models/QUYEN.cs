namespace QLBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYEN")]
    public partial class QUYEN
    {
        [Key]
        [StringLength(8)]
        public string maquyen { get; set; }

        [Required]
        [StringLength(20)]
        public string tenquyen { get; set; }
    }
}
