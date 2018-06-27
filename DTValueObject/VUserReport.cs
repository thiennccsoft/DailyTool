using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObject
{
   public class VUserReport
    {
        [Display(Name = "Báo cáo của người dùng")]
        public Guid UserReportId { get; set; }
        [Display(Name = "Người dùng")]
        public Guid UserId { get; set; }
        [Display(Name = "Quyền")]
        public Guid ReportId { get; set; }
    }
}
