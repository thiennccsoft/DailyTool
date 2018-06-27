using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObject
{
    public class VReportItem
    {
        [Display(Name ="Mã báo cáo")]
        public Guid ReportId { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        public string Title { get; set; }

        [Display(Name = "Dự định")]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        public string DuDinh { get; set; }

        [Display(Name = "Kết thúc")]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        public bool? IsFinish { get; set; }

        [Display(Name = "Kế hoạch")]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        public string KeHoach { get; set; }

        [Display(Name = "Vấn đề gặp phải")]
        public string Issue { get; set; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Hãy nhập dữ liệu cho trường này")]
        public DateTime? CreatedAt { get; set; }
    }
}
