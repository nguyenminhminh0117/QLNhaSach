namespace QLBanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [Key]
        [StringLength(8)]
        [Display(Name = "Mã khách hàng")]
        public string makh { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Tên khách hàng là bắt buộc!")]
        [RegularExpression("^([^0-9]*)([^%@#$&*])$", ErrorMessage = "Tên khách hàng không hợp lệ!")]
        [Display(Name = "Tên khách hàng")]
        public string tenkh { get; set; }
        
        [Required(ErrorMessage = "Địa chỉ là bắt buộc!")]
        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        public string diachi { get; set; }
        
        [StringLength(12)]
        [Required(ErrorMessage = "Số điện thoại là bắt buộc!")]
        [RegularExpression("^[0-9]{10,11}$", ErrorMessage = "Số điện thoại không hợp lệ!")]
        [Display(Name = "Số điện thoại")]
        public string sodienthoai { get; set; }
        
        [Required(ErrorMessage = "Email là bắt buộc!")]
        [StringLength(50, ErrorMessage = "Chiều dài email lớn nhất là 50")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập lại email!")]
        [Display(Name = "Email")]
        public string email { get; set; }
        
        [Required(ErrorMessage = "Mật khẩu là bắt buộc!")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Chiều dài mật khẩu phải lớn hơn 10 và nhỏ hơn 50")]
        [DataType("password")]
        [Display(Name = "Mật khẩu")]
        public string matkhaukh { get; set; }
    }
}
