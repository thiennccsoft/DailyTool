using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObject
{
    public class VRole
    {
        [Display(Name ="Mã quyền")]
        public int RoleId { get; set; }
        [Display(Name = "Tên quyền")]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        public string RoleName { get; set; }
    }
}
