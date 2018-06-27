using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObject
{
   public class VUser: IdentityUser
    {
        [Display(Name ="Mã người dùng")]
        public Guid UserId { get; set; }

        [Display(Name = "Tên người dùng")]
        [Required(ErrorMessage ="Hãy nhập dữ liệu cho trường này")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        [Display(Name = "Ngày tạo")]
        public DateTime? CreateAt { get; set; }

        [Display(Name = "Người nhận báo cáo")]
        public Guid? ReportReceiver { get; set; }

        [Display(Name = "Quyền")]
        public int RoleId { get; set; }
    }
}
