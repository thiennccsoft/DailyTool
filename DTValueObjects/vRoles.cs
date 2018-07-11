using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
<<<<<<< HEAD
namespace DTValueObjects
{
    public class vRoles 
=======

namespace DTValueObjects
{
    public class vRoles
>>>>>>> 7a2fbeefdc9b16a90e69c0678e0bc1f8afcf09a2
    {
        [Display(Name = "Mã chức vụ")]
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Tên chức vụ")]
        [StringLength(250)]
        public string RoleName { get; set; }
    }
}
