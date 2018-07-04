using System;
using System.Collections.Generic;
using System.Text;
using DTBLL.BaseController;
using DTValueObjects;
using DTModels.Models;

namespace DTBLL.Controllers
{
    public class PlanItemDTcontroller:BasePlanItem<vPlanItems>
    {
        private PlanItemModel pi = new PlanItemModel();
        public override List<vPlanItems> GetAll()
        {
            return pi.GetAll();

        }
        public  vPlanItems GetbyId(Guid PI)
        {
            return pi.GetbyId(PI);
        }
        public override bool Insert(vPlanItems PI)
        {
            return pi.Insert(PI);
        }
        public override bool Delete(vPlanItems PI)
        {
            return pi.Delete(PI);
        }
    }
}
