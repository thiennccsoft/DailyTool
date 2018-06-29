using System;
using System.Collections.Generic;
using System.Text;
using DTControllers.BaseControllers;
using DTModels.Models;
using DTValueObjects;

namespace DTControllers.Controllers
{
    public class UserControllers:BaseUser<vUser>
    {
        private UserModel uModel = new UserModel();
        public override List<vUser> Getall()
        {
            return uModel.Getall();
        }
        public override bool Insert(vUser user)
        {
            return uModel.Insert(user);
        }
        public override bool Update(vUser user)
        {
            return uModel.Update(user);
        }
        public override bool Delete(vUser user)
        {
            return uModel.Delete(user);
        }
        public override vUser CheckLogin(vUser user)
        {
            return uModel.Checklogin(user);
        }
        public override bool CreateUser(vUser user)
        {
            return uModel.CreateUser(user);
        }
    }
}
