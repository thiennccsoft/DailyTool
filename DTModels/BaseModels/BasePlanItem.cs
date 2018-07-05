using System;
using System.Collections.Generic;
using System.Text;
using DTModels.Database;

namespace DTModels.BaseModels
{
    public class BasePlanItem<T>
    {
        protected PlanDailyContext db = new PlanDailyContext();
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual bool Insert(T PI)
        { return false; }

        public virtual bool Delete(T PI)
        { return false; }

    }
}
