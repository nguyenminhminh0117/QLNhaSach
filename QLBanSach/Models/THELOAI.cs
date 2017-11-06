namespace QLBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THELOAI")]
    public partial class THELOAI
    {
        [Key]
        [StringLength(8)]
        public string matheloai { get; set; }

        [Required]
        [StringLength(25)]
        public string tentheloai { get; set; }
    }
}
