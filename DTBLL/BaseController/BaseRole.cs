﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTBLL.BaseController
{
    public class BaseRole<T>
    {
        public virtual List<T> GetAll() { List<T> list = new List<T>(); return list; }
        public virtual bool Insert(T role)
        { return false; }
        public virtual bool Update(T usroleer)
        { return false; }

        public virtual bool Delete(T role)
        { return false; }
    }
}
