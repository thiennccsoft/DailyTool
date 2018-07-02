using System;
using System.Collections.Generic;
using System.Text;
using DTModels.Database;

namespace DTModels.BaseModels
{
    public class BaseUserReport<T>
    {
        protected PlanDailyContext db = new PlanDailyContext();
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual bool Insert(T UR)
        { return false; }

        public virtual bool Delete(T UR)
        { return false; }
        public virtual T GetbyId(T UR)
        {
            return UR;
        }
    }
}
