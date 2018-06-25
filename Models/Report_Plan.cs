using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DailyTool.Models
{
    public class Report_Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Report_Plane_Id { get; set; }
        public Guid ReportId { get; set; }
        public Guid PlandId { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
