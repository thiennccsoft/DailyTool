using System;
using System.Collections.Generic;
using System.Text;

namespace DTValueObjects
{
    public class vUser
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid? ReportReceiver { get; set; }
        public int RoleId { get; set; }
    }
}
