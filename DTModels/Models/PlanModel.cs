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
    public class PlanModel : BasePlan<vPlans>
    {
        public override List<vPlans> GetAll()
        {
            List<vPlans> listplan = new List<vPlans>();
            var listP = db.Plans;
            foreach (var item in listP)
            {
                vPlans plan = new vPlans();
                plan = changetovPlan(item);

                listplan.Add(plan);
            }
            return listplan;
        }
        public override List<vPlans> GetbyPaging(int pageIndex, int pageSize)
        {
            int rc = 0;
            var listplan = from t in (db.Plans.OrderBy(x => x.Created_At).Distinct().ToList())
                           select new
                           {
                               RowNumber = ++rc,
                               t.PlanId,
                               t.ReportId,
                               t.Status,
                               t.Created_At
                           };
            var listab = from i in listplan
                         where i.RowNumber > pageIndex && i.RowNumber <= (pageIndex + pageSize)
                         select new
                         {
                             i.PlanId,
                             i.ReportId,
                             i.Status,
                             i.Created_At
                         };
            List<vPlans> listP = new List<vPlans>();
            foreach (var item in listab)
            {
                vPlans nplan = new vPlans();
                nplan.PlanId = item.PlanId;
                nplan.ReportId = item.ReportId;
                nplan.Status = item.Status;
                nplan.Created_At = item.Created_At;

                listP.Add(nplan);
            }
            return listP;
        }
        public override vPlans GetbyId(vPlans plan)
        {
            var kq = db.Plans.ToList().Find(x => x.PlanId == plan.PlanId);
            vPlans nplan = new vPlans();
            nplan = changetovPlan(kq);
            return nplan;
        }
        public override bool Insert(vPlans plan)
        {
            Plans nplan = changetoPlan(plan);
            db.Plans.Add(nplan);
            db.SaveChanges();
            return true;
        }
        public override bool Update(vPlans plan)
        {
            Plans nplan = db.Plans.ToList().Find(x => x.PlanId == plan.PlanId);
            db.Attach(nplan);
            nplan = changetoPlan(plan);
            db.Entry(nplan).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public override bool Delete(vPlans plan)
        {
            Plans nplan = changetoPlan(plan);
            db.Plans.Remove(nplan);
            db.SaveChanges();
            return true;
        }
        public Plans changetoPlan(vPlans vplan)
        {
            Plans nplan = new Plans();
            nplan.PlanId = vplan.PlanId;
            nplan.ReportId = vplan.ReportId;
            nplan.Status = vplan.Status;
            nplan.Created_At = vplan.Created_At;
            return nplan;
        }
        public vPlans changetovPlan(Plans plan)
        {
            vPlans nplan = new vPlans();
            nplan.PlanId = plan.PlanId;
            nplan.ReportId = plan.ReportId;
            nplan.Status = plan.Status;
            nplan.Created_At = plan.Created_At;
            return nplan;
        }
    }
}
