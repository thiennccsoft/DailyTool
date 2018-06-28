using System;
using System.Collections.Generic;

namespace DTModels.Database
{
    public partial class Users
    {
        public Users()
        {
            UserReports = new HashSet<UserReports>();
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public DateTime? CreateAt { get; set; }
        public Guid? ReportReceiver { get; set; }
        public int RoleId { get; set; }

        public Roles Role { get; set; }
        public ICollection<UserReports> UserReports { get; set; }
    }
}
