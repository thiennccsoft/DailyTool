using System;
using System.Collections.Generic;
using System.Text;
using DTModels.Database;

namespace DTModels.BaseModels
{
    public class BaseItem<T>
    {
        protected PlanDailyContext db = new PlanDailyContext();
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual List<T> GetbyPaging(int pageIndex, int pageSize) { return new List<T>(); }
        public virtual bool Insert(T Item)
        { return false; }
        public virtual bool Update(T Item)
        { return false; }

        public virtual bool Delete(T Item)
        { return false; }
    }
}
