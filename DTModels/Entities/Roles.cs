using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTModels.Entities
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [Display(Name ="Vai trò")]
        public string RoleName { get; set; }

        public Roles()
        {
        }

        public Roles(int roleId, string roleName)
        {
            RoleId = roleId;
            RoleName = roleName;
        }

        public virtual ICollection<Users> Users { get; set; }

    }
}
