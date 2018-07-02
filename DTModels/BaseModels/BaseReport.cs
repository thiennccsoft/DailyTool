using System;
using System.Collections.Generic;
using System.Text;
using DTModels.Database;

namespace DTModels.BaseModels
{
    class BaseReport<T>
    {
        protected PlanDailyContext db = new PlanDailyContext();
        public virtual bool Insert(T user) { return false; }
        public virtual bool Delete(T user) { return false; }
    }
}
