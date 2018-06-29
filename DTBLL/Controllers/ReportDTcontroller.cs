using System;
using System.Collections.Generic;
using System.Text;
using DTBLL.BaseController;
using DTModels.Models;
using DTValueObjects;

namespace DTBLL.Controllers
{
    public class ReportDTcontroller:BaseReport<vReports>
    {
        private ReportModel rp = new ReportModel();
        public override List<vReports> GetAll()
        {
            return rp.GetAll();
        }
        public override List<vReports> GetbyPaging(int pageIndex, int pageSize)
        {
            return rp.GetbyPaging(pageIndex, pageSize);
        }
        public override vReports GetbyId(vReports RePort)
        {
            return rp.GetbyId(RePort);
        }
        public override bool Insert(vReports RePort)
        {
            return rp.Insert(RePort);
        }
        public override bool Update(vReports RePort)
        {
            return rp.Update(RePort);
        }
        public override bool Delete(vReports RePort)
        {
            return rp.Delete(RePort);
        }
    }
}
