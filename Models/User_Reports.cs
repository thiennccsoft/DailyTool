using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DailyTool.Models
{
    public class User_Reports
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid User_Report_Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ReportId { get; set; }
    }
}
