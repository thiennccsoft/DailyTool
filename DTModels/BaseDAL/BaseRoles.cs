using System;
using System.Collections.Generic;
using System.Text;

namespace DTModels.BaseDAL
{
    public class BaseRoles<T>
    {
        public virtual List<T> GetAllRole() { List<T> list = new List<T>();return list; }
        public virtual bool Insert(T role) { return false; }

    }
}
