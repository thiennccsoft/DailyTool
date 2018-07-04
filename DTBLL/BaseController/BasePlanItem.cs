using System;
using System.Collections.Generic;
using System.Text;

namespace DTBLL.BaseController
{
    public class BasePlanItem<T>
    {
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual bool Insert(T PI)
        { return false; }

        public virtual bool Delete(T PI)
        { return false; }
    }
}
