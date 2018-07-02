using System;
using System.Collections.Generic;
<<<<<<< HEAD

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
=======
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DTModels.Database
{
    public class Plans
    {
        [Key]
        public Guid PlanId { get; set; }
        [Required]
        public Guid ReportId { get; set; }
        [Required]
        [StringLength(500)]
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

        [Required]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime Created_At { get; set; }

        public Reports Reports { get; set; }
        public virtual ICollection<Plan_Items> Plan_Items { get; set; }

        public Plans(Guid planId, Guid reportid, int status, DateTime created_At)
        {
            PlanId = planId;
            ReportId = reportid;
            Status = status;
            Created_At = created_At;
        }

        public Plans()
        {
        }
    }
}   
>>>>>>> master
