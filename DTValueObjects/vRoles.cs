using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObjects
{
    public class vRoles
    {
        [Display(Name = "Mã chức vụ")]
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Tên chức vụ")]
        [StringLength(250)]
        public string RoleName { get; set; }
    }
}
