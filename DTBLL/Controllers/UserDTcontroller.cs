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
<<<<<<< HEAD
        public vUsers CheckLogin(string username, string password)
=======
        public  vUsers CheckLogin(string username, string password)
>>>>>>> Quan
        {
            return udm.CheckLogin(username, password);
        }
        public override List<vUsers> GetbyPaging(int pageIndex, int pageSize)
        {
            return udm.GetbyPaging(pageIndex, pageSize);
        }
<<<<<<< HEAD
        public vUsers GetbyId(Guid userid)
=======
        public  vUsers GetbyId(Guid userid)
>>>>>>> Quan
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
<<<<<<< HEAD
        public vUsers getUserByUserName(string user)
        {
            return udm.getUserByUserName(user);
=======

        public List<vUsers> getUsersNotReport()
        {
            return udm.getUsersNotReport();
>>>>>>> Quan
        }
    }
}
