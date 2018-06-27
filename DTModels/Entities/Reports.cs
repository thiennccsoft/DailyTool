using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTModels.Entities
{
    public class Reports
    {
        [Key]
        public Guid ReportId { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Dự định")]
        public string Du_dinh { get; set; }

        public bool IsFinish { get; set; }

        [Required]
        [Display(Name = "Kế hoạch")]
        public string Ke_hoach { get; set; }

        [Required]
        [Display(Name = "Vấn đề")]
        public string Issue { get; set; }

        [Required]
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime Created_At { get; set; }

        public virtual ICollection<User_Reports> User_Reports { get; set; }
        public virtual ICollection<Report_Items> Report_Items { get; set; }

        public Reports(Guid reportId, string title, string du_dinh, bool isFinish, string ke_hoach, string issue, DateTime created_At)
        {
            ReportId = reportId;
            Title = title;
            Du_dinh = du_dinh;
            IsFinish = isFinish;
            Ke_hoach = ke_hoach;
            Issue = issue;
            Created_At = created_At;
        }

        public Reports()
        {
            IsFinish = false;
        }
    }
}
