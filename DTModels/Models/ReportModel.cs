using System;
using System.Collections.Generic;
using System.Text;
using DTValueObjects;
using DTModels.Database;
using DTModels.BaseModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DTModels.Models
{
    public class ReportModel : BaseReport<vReports>
    {
        public override List<vReports> GetAll()
        {
            List<vReports> listrp = new List<vReports>();
            var listreport = db.Reports;
            foreach (var item in listreport)
            {
                vReports report = new vReports();
                report = changetovReport(item);

                listrp.Add(report);
            }
            return listrp;
        }
<<<<<<< HEAD
        public vReports GetbyId(Guid rePortid)
=======
        public  vReports GetbyId(Guid rePortid)
>>>>>>> Quan
        {
            var kq = db.Reports.ToList().Find(x => x.ReportId == rePortid);
            vReports vreport = new vReports();
            vreport = changetovReport(kq);

            return vreport;
        }
        public override List<vReports> GetbyPaging(int pageIndex, int pageSize)
        {
            int rc = 0;
            var listreport = from t in (db.Reports.OrderBy(x => x.Created_At).Distinct().ToList())
                           select new
                           {
                               RowNumber = ++rc,
                               t.ReportId,
                               t.Title,
                               t.Description,
                               t.Issue,
                               t.Created_At
                           };
            var listab = from i in listreport
                         where i.RowNumber > pageIndex && i.RowNumber <= (pageIndex + pageSize)
                         select new
                         {
                             i.ReportId,
                             i.Title,
                             i.Description,
                             i.Issue,
                             i.Created_At
                         };
            List<vReports> listRP = new List<vReports>();
            foreach (var item in listab)
            {
                vReports report = new vReports();
                report.ReportId = item.ReportId;
                report.Title = item.Title;
                report.Description = item.Description;
                report.Issue = item.Issue;
                report.Created_At = item.Created_At;

                listRP.Add(report);
            }
            return listRP;
        }
        public override bool Insert(vReports RePort)
        {
            Reports report = changetoReport(RePort);
            db.Reports.Add(report);
            db.SaveChanges();
            return true;
        }
        public override bool Update(vReports RePort)
        {
            Reports report = db.Reports.ToList().Find(x => x.ReportId == RePort.ReportId);
            //db.Attach(report);
            //report = changetoReport(RePort);
            //db.Entry(report).State = EntityState.Modified;
            report.Title = RePort.Title;
            report.Description = RePort.Description;
            report.Issue = RePort.Issue;
            db.SaveChanges();
            return true;
        }
        public override bool Delete(vReports RePort)
        {
            Reports report = changetoReport(RePort);
            db.Reports.Remove(report);
            db.SaveChanges();
            return true;
        }
        public Reports changetoReport(vReports vreport)
        {
            Reports rp = new Reports();

            rp.ReportId = vreport.ReportId;
            rp.Title = vreport.Title;
            rp.Description = vreport.Description;
            rp.Issue = vreport.Issue;
            rp.Created_At = vreport.Created_At;
            return rp;
        }
        public vReports changetovReport(Reports report)
        {
            vReports rp = new vReports();

            rp.ReportId = report.ReportId;
            rp.Title = report.Title;
            rp.Description = report.Description;
            rp.Issue = report.Issue;
            rp.Created_At = report.Created_At;
            return rp;
        }
    }
}
