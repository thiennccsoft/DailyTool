using System;
using System.Collections.Generic;
using System.Text;

namespace DTBLL.BaseController
{
    public class BaseItem<T>
    {
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual List<T> GetbyPaging(int pageIndex, int pageSize) { return new List<T>(); }
        public virtual bool Insert(T Item)
        { return false; }
        public virtual bool Update(T Item)
        { return false; }

        public virtual bool Delete(T Item)
<<<<<<< HEAD
        { return false; }
=======
        { return false; } 
>>>>>>> Quan
    }
}
