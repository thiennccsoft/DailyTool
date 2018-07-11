using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObjects.ViewModels
{
    public class ChangePasswordModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên tài khoản phải dài hơn 3 kí tự!")]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải dài hơn 6 kí tự!")]
        [Display(Name = "Mật khẩu mới")]
        [DataType(DataType.Password)]
       
        public string NewPassWord { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải dài hơn 6 kí tự!")]
        [Display(Name = "Mật khẩu cũ")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải dài hơn 6 kí tự!")]
        [Display(Name = "Nhập lại khẩu mới")]
        [Compare("NewPassWord", ErrorMessage = "The new password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ComfirmPassWord { get; set; }
        public int Code { set; get; }
        public string Email { set; get; }
    }
}
