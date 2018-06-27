using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObject
{
    public class VPlan
    {
        [Display(Name ="Mã kế hoạch")]
        public Guid PlanId { get; set; }

        [Display(Name = "Tên kế hoạch")]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        public string Title { get; set; }

        [Display(Name = "Mô tả kế hoạch")]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        public string Description { get; set; }

        [Display(Name = "")]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        public double? FinishRate { get; set; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        public DateTime? CreateAt { get; set; }
    }
}
