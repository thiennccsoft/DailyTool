using System;
using System.Collections.Generic;
using System.Text;
using DTValueObject;
namespace DTModels.BaseDAL
{
    public class BaseUsers<T>
    {
        public virtual T Checklogin(T user) { return user; }
        public virtual bool Insert(T user) { return false; }
        public virtual List<T> GetAll(T user) { List<T> list = new List<T>();return list; }
    }
}
