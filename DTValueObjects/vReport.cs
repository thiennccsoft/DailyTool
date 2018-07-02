using System;
using System.Collections.Generic;
using System.Text;

namespace DTValueObjects
{
    public class vReport
    {
        public Guid ReportId { get; set; }
        public string Title { get; set; }
        public string Issues { get; set; }
        public DateTime? CreateAt { get; set; }
        public Guid PlanToday {get; set; }
        public Guid PlanTormorow { get; set; }
    }
}
