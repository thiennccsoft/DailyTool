using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DailyTool.Models
{
    public class Plans
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PlanId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float FinishRate { get; set; }
        public DateTime Create_At { get; set; }
    }
}
