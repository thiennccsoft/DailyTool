using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTValueObjects
{
    public class vReports
    {
        public Guid ReportId { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }


        [Display(Name = "Nội dung")]
        public string Description { get; set; }


        [Display(Name = "Vấn đề")]
        public string Issue { get; set; }

        [Required]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime Created_At { get; set; }
    }
}
