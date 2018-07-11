using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObjects
{
    public class vUsers
    {
        public Guid UserId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên tài khoản phải dài hơn 3 kí tự!")]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải dài hơn 6 kí tự!")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải dài hơn 6 kí tự!")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string OldPassWord { get; set; }
        
        public Guid? ReportReciver { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày tạo")]
        public DateTime Created_At { get; set; }

        public int RoleId { get; set; }
    }
}
