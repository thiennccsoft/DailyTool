using System;
using System.Collections.Generic;
using System.Text;
using DTBLL.BaseController;
using DTModels.Models;
using DTValueObjects;

namespace DTBLL.Controllers
{
    public class UserReportDTcontroller:BaseUserReport<vUserReports>
    {
        private UserReportModel urp = new UserReportModel();
        public override List<vUserReports> GetAll()
        {
            return urp.GetAll();
        }
<<<<<<< HEAD
        public vUserReports GetbyId(Guid UR)
=======
        public  vUserReports GetbyId(Guid UR)
>>>>>>> Quan
        {
            return urp.GetbyId(UR);
        }
        public override bool Insert(vUserReports UR)
        {
            return urp.Insert(UR);
        }
        public override bool Delete(vUserReports UR)
        {
            return urp.Delete(UR);
        }
    }
}
