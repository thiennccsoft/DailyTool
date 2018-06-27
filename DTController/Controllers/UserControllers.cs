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
    }
}
