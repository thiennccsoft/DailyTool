using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTValueObjects.ViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public Guid ReportReceiver { get; set; }
    }
}
