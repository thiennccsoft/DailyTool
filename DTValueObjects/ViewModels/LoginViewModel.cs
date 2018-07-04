using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTValueObjects.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên tài khoản phải dài hơn 3 kí tự!")]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải dài hơn 6 kí tự!")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}
