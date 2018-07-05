using System;
using System.Collections.Generic;
using System.Text;

namespace DTBLL.BaseController
{
    public class BasePlan<T>
    {
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual List<T> GetbyPaging(int pageIndex, int pageSize) { return new List<T>(); }
        public virtual bool Insert(T plan)
        { return false; }
        public virtual bool Update(T plan)
        { return false; }

        public virtual bool Delete(T plan)
        { return false; }
    }
}
