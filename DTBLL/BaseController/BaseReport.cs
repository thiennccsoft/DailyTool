using System;
using System.Collections.Generic;
using System.Text;

namespace DTBLL.BaseController
{
    public class BaseReport<T>
    {
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual List<T> GetbyPaging(int pageIndex, int pageSize) { return new List<T>(); }
        public virtual bool Insert(T RePort)
        { return false; }
        public virtual bool Update(T RePort)
        { return false; }

        public virtual bool Delete(T RePort)
        { return false; }
<<<<<<< HEAD
=======

>>>>>>> Quan
    }
}
