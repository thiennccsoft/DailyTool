using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DTModels.Database
{
    public class Users
    {
        [Key]
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

        public Guid? ReportReciver { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày tạo")]
        public DateTime Created_At { get; set; }

        public int RoleId { get; set; }

        public virtual ICollection<User_Reports> User_Reports { get; set; }
        public Roles Roles { get; set; }

        public Users(Guid userId, string userName, string email, string passWord, Guid reportReciver, DateTime created_At, int roleId)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            PassWord = passWord;
            ReportReciver = reportReciver;
            Created_At = created_At;
            RoleId = roleId;
        }

        public Users()
        {
        }
    }
}