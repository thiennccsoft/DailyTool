using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTModels.Database
{
    public class Reports
    {
        [Key]
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

        public virtual ICollection<User_Reports> User_Reports { get; set; }
        public virtual ICollection<Plans> Report_Items { get; set; }

        public Reports(Guid reportId, string title, string description, string issue, DateTime created_At)
        {
            ReportId = reportId;
            Title = title;
            Description = description;
            Issue = issue;
            Created_At = created_At;
        }

        public Reports()
        {
        }
    }
}