using System;
using System.Collections.Generic;
using System.Text;
using DTBLL.BaseController;
using DTModels.Models;
using DTValueObjects;


namespace DTBLL.Controllers
{
    public class UserDTcontroller:BaseUser<vUsers>
    {
        private UserModel udm = new UserModel();
        public override List<vUsers> GetAll()
        {
            return udm.GetAll();
        }
        public override vUsers CheckLogin(vUsers user)
        {
            return udm.CheckLogin(user);
        }
        public override List<vUsers> GetbyPaging(int pageIndex, int pageSize)
        {
            return udm.GetbyPaging(pageIndex, pageSize);
        }
        public override vUsers GetbyId(vUsers user)
        {
            return udm.GetbyId(user);
        }
        public override bool Insert(vUsers user)
        {
            return udm.Insert(user);
        }
        public override bool Update(vUsers user)
        {
            return udm.Update(user);
        }
        public override bool Delete(vUsers user)
        {
            return udm.Delete(user);
        }
    }
}
