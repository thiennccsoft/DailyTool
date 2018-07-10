using System;
using System.Collections.Generic;
using System.Text;
using DTModels.Database;

namespace DTModels.BaseModels
{
    public class BaseRole<T>
    {
        protected PlanDailyContext db = new PlanDailyContext();
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual bool Insert(T role)
        { return false; }
        public virtual bool Update(T usroleer)
        { return false; }

        public virtual bool Delete(T role)
        { return false; }

   }
}
