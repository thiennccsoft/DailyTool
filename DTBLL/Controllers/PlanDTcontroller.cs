using System;
using System.Collections.Generic;
using System.Text;
using DTBLL.BaseController;
using DTModels.Models;
using DTValueObjects;

namespace DTBLL.Controllers
{
    public class PlanDTcontroller:BasePlan<vPlans>
    {
        private PlanModel pl = new PlanModel();
        public override List<vPlans> GetAll()
        {
            return pl.GetAll();
        }
        public  vPlans GetbyId(Guid plan)
        {
            return pl.GetbyId(plan);
        }
        public override List<vPlans> GetbyPaging(int pageIndex, int pageSize)
        {
            return pl.GetbyPaging(pageIndex, pageSize);
        }
        public override bool Insert(vPlans plan)
        {
            return pl.Insert(plan);
        }
        public override bool Update(vPlans plan)
        {
            return pl.Update(plan);
        }
        public override bool Delete(vPlans plan)
        {
            return pl.Delete(plan);
        }
    }
}
