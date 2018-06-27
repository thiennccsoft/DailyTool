using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObject
{
   public class VReportPlan
    {
        [Display(Name = "Mã báo cáo kế hoạch")]
        public Guid ReportPlaneId { get; set; }

        [Display(Name = "Mã báo cáo")]
        public Guid ReportId { get; set; }

        [Display(Name = "Mã kế hoạch")]
        public Guid PlanId { get; set; }

        [Display(Name = "Ngày kết thúc")]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        [DataType(DataType.Date)]
        public DateTime? FinishDate { get; set; }
    }
}
