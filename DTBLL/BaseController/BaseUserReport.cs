using System;
using System.Collections.Generic;
using System.Text;

namespace DTBLL.BaseController
{
    public class BaseUserReport<T>
    {
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual bool Insert(T UR)
        { return false; }

        public virtual bool Delete(T UR)
        { return false; }
    }
}
