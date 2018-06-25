using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DailyTool.Models
{
    public class ReportItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReportId { get; set; }
        public string Title { get; set; }
        public string Du_dinh { get; set; }
        public bool IsFinish { get; set; }
        public string Ke_hoach { get; set; }
        public string Issue { get; set; }
        public DateTime Created_At { get; set; }

    }
}
