using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObjects
{
    public class vPlans
    {
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
        
    }
}
