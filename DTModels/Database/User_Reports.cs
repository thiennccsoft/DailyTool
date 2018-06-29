using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DTModels.Database
{
    public class User_Reports
    {
        [Key]
        public Guid User_report_Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ReportId { get; set; }
        public Users Users { get; set; }
        public Reports Report { get; set; }

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