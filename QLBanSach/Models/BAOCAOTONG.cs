namespace QLBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAOCAOTONG")]
    public partial class BAOCAOTONG
    {
        [Key]
        public DateTime ngay { get; set; }

        public int tongthu { get; set; }

        public int tongchi { get; set; }

        public int chenhlech { get; set; }

        public int delflag { get; set; }

        public DateTime? timedel { get; set; }
    }
}
