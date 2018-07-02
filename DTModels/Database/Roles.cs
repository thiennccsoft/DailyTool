using System;
using System.Collections.Generic;
<<<<<<< HEAD

namespace DTModels.Database
{
    public partial class Roles
    {
        public Roles()
        {
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
=======
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DTModels.Database
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Tên chức vụ")]
        [StringLength(250)]
        public string RoleName { get; set; }

        public Roles(int roleId, string roleName)
        {
            RoleId = roleId;
            RoleName = roleName;
        }

        public virtual ICollection<Users> Users { get; set; }

        public Roles()
        {
        }
    }
}
>>>>>>> master
