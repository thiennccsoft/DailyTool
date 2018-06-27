

using System;

namespace DailyTool.ViewModels
{
  //class register
    public class RegistrationViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime CreateAt { get; set; }
        public int RoleId { set; get; }
        public Guid? ReportReceiver { get; set; }
    }
}
