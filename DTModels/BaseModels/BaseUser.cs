using System;
using System.Collections.Generic;
using System.Text;
using DTModels.Database;

namespace DTModels.BaseModels
{
    public class BaseUser<T>
    {
        protected PlanDailyContext db = new PlanDailyContext();
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual List<T> GetbyPaging(int pageIndex, int pageSize) { return new List<T>(); }
        public virtual bool Insert(T user)
        { return false; }
        public virtual bool Update(T user)
        { return false; }

        public virtual bool Delete(T user)
        { return false; }
    }
}
