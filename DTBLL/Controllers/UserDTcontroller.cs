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
        public vUsers CheckLogin(string username, string password)
        {
            return udm.CheckLogin(username, password);
        }
        public override List<vUsers> GetbyPaging(int pageIndex, int pageSize)
        {
            return udm.GetbyPaging(pageIndex, pageSize);
        }
        public vUsers GetbyId(Guid userid)
        {
            return udm.GetbyId(userid);
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
