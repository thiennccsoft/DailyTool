using System;
using System.Collections.Generic;
using System.Text;
using DTModels.Entities;

namespace DTModels.BaseModels
{
    public class BaseUser<T>
    {
        protected DailyDBContext db = new DailyDBContext();
        public virtual List<T> Getall() { List<T> list = new List<T>(); return list; }
        public virtual List<T> Getbypaging(int PageIndex, int PageSize, string yeucau) { List<T> list = new List<T>(); return list; }
        public virtual bool Insert(T user) { return false; }
        public virtual bool Update(T user) { return false; }
        public virtual bool Delete(T user) { return false; }
        public virtual T Checklogin(T user) { return user; }
        public virtual bool CreateUser(T user) { return false; }
    }
}
