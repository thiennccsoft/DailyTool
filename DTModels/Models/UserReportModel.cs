using System;
using System.Collections.Generic;
using System.Text;
using DTModels.BaseModels;
using DTValueObjects;
using DTModels.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DTModels.Models
{
    public class UserReportModel:BaseUserReport<vUserReports>
    {
        public override List<vUserReports> GetAll()
        {
            List<vUserReports> listUrp = new List<vUserReports>();
            var listurp = db.User_Reports;
            foreach (var item in listurp)
            {
                vUserReports urp = new vUserReports();
                urp = changetovUserRP(item);

                listUrp.Add(urp);
            }
            return listUrp;
        }
<<<<<<< HEAD
        public vUserReports GetbyId(Guid id)
=======
        public  vUserReports GetbyId(Guid id)
>>>>>>> Quan
        {
            var kq = db.User_Reports.ToList().Find(x => x.User_report_Id == id);
            vUserReports nurp = new vUserReports();
            nurp = changetovUserRP(kq);

            return nurp;
        }
        public override bool Insert(vUserReports UR)
        {
            User_Reports nurp = changetoUserRP(UR);
            db.User_Reports.Add(nurp);
            db.SaveChanges();
            return true;
        }
        public override bool Delete(vUserReports UR)
        {
            User_Reports nurp = changetoUserRP(UR);
            db.User_Reports.Remove(nurp);
            db.SaveChanges();
            return true;
        }

        public User_Reports changetoUserRP(vUserReports vuserrp)
        {
            User_Reports nuserrp = new User_Reports();
            nuserrp.User_report_Id = vuserrp.User_report_Id;
            nuserrp.UserId = vuserrp.UserId;
            nuserrp.ReportId = vuserrp.ReportId;
            return nuserrp;
        }
        public vUserReports changetovUserRP(User_Reports userrp)
        {
            vUserReports nuserrp = new vUserReports();
            nuserrp.User_report_Id = userrp.User_report_Id;
            nuserrp.UserId = userrp.UserId;
            nuserrp.ReportId = userrp.ReportId;
            return nuserrp;
        }
        
    }
}
