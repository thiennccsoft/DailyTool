using System;
using System.Collections.Generic;

namespace DTModels.Database
{
    public partial class ReportItems
    {
        public ReportItems()
        {
            ReportPlan = new HashSet<ReportPlan>();
            UserReports = new HashSet<UserReports>();
        }

        public Guid ReportId { get; set; }
        public string Title { get; set; }
        public string DuDinh { get; set; }
        public bool? IsFinish { get; set; }
        public string KeHoach { get; set; }
        public string Issue { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ICollection<ReportPlan> ReportPlan { get; set; }
        public ICollection<UserReports> UserReports { get; set; }
    }
}
