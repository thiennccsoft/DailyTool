using System;
using System.Collections.Generic;

namespace DTModels.Database
{
    public partial class Plans
    {
        public Plans()
        {
            ReportPlan = new HashSet<ReportPlan>();
        }

        public Guid PlanId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double? FinishRate { get; set; }
        public DateTime? CreateAt { get; set; }

        public ICollection<ReportPlan> ReportPlan { get; set; }
    }
}
