using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTModels.Entities
{
    public class Report_Items
    {
        [Key]
        public Guid ReportId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime FinishDate { get; set; }

        public Report_Items(Guid reportId, Guid planId, DateTime finishDate)
        {
            ReportId = reportId;
            PlanId = planId;
            FinishDate = finishDate;
        }

        public Report_Items()
        {
        }
    }
}
