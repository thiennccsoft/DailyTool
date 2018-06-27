using System;
using System.Collections.Generic;

namespace DTModels.Database
{
    public partial class UserReports
    {
        public Guid UserReportId { get; set; }
        public Guid UserId { get; set; }
        public Guid ReportId { get; set; }

        public Users User { get; set; }
        public ReportItems ReportItems { get; set; }
    }
}
