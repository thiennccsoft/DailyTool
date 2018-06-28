using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTModels.Entities
{
    public class User_Reports
    {
        [Key]
        public Guid User_report_Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ReportId { get; set; }

        public User_Reports(Guid user_report_Id, Guid userId, Guid reportId)
        {
            User_report_Id = user_report_Id;
            UserId = userId;
            ReportId = reportId;
        }

        public User_Reports()
        {
        }
    }
}
