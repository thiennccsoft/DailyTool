using System;
using System.Collections.Generic;
using System.Text;

namespace DTBLL.BaseController
{
    public class BaseUser<T>
    {
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual List<T> GetbyPaging(int pageIndex, int pageSize) { return new List<T>(); }
        public virtual T CheckLogin(T user)
        {
            return user;
        }
        public virtual bool Insert(T user)
        { return false; }
        public virtual bool Update(T user)
        { return false; }

        public virtual bool Delete(T user)
        { return false; }
        public virtual T GetbyId(T user)
        {
            return user;
        }
    }
}
