using System;
using System.Collections.Generic;

namespace DTModels.Database
{
    public partial class ReportPlan
    {
        public Guid ReportPlaneId { get; set; }
        public Guid ReportId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime? FinishDate { get; set; }

        public Plans Plan { get; set; }
        public ReportItems Report { get; set; }
    }
}
