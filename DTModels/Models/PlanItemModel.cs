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
    public class PlanItemModel:BasePlanItem<vPlanItems>
    {
        public override List<vPlanItems> GetAll()
        {
            List<vPlanItems> listPI = new List<vPlanItems>();
            var listplanI = db.Plan_Items;
            foreach (var item in listplanI)
            {
                vPlanItems plan = new vPlanItems();
                plan = changetovPlanItem(item);

                listPI.Add(plan);
            }
            return listPI;
        }
<<<<<<< HEAD
        public vPlanItems GetbyId(Guid PIid)
=======
        public  vPlanItems GetbyId(Guid PIid)
>>>>>>> Quan
        {
            var kq = db.Plan_Items.ToList().Find(x => x.Plan_ItemId == PIid);
            vPlanItems nplanit = new vPlanItems();
            nplanit = changetovPlanItem(kq);

            return nplanit;
        }
        public override bool Insert(vPlanItems PI)
        {
            Plan_Items nplanI = changetoPlanItem(PI);
            db.Plan_Items.Add(nplanI);
            db.SaveChanges();
            return true;
        }
        public override bool Delete(vPlanItems PI)
        {
            Plan_Items nplanI = changetoPlanItem(PI);
            db.Plan_Items.Remove(nplanI);
            db.SaveChanges();
            return true;
        }
        public Plan_Items changetoPlanItem(vPlanItems vplan)
        {
            Plan_Items planI = new Plan_Items();
            planI.Plan_ItemId = vplan.Plan_ItemId;
            planI.ItemId = vplan.ItemId;
            planI.PlanId = vplan.PlanId;
            return planI;
        }
        public vPlanItems changetovPlanItem(Plan_Items plan)
        {
            vPlanItems planI = new vPlanItems();
            planI.Plan_ItemId = plan.Plan_ItemId;
            planI.ItemId = plan.ItemId;
            planI.PlanId = plan.PlanId;
            return planI;
        }
    }
}
