using System;
using System.Collections.Generic;
using System.Text;
using DTBLL.BaseController;
using DTModels.Models;
using DTValueObjects;

namespace DTBLL.Controllers
{
    public class RoleDTcotroller:BaseRole<vRoles>
    {
        RoleModel rl = new RoleModel();
        public override List<vRoles> GetAll()
        {
            return rl.GetAll();
        }
        public vRoles GetbyId(int role)
        {
            return rl.GetbyId(role);
        }
        public override bool Insert(vRoles role)
        {
            return rl.Insert(role);

        }
        public override bool Update(vRoles usroleer)
        {
            return rl.Update(usroleer);
        }
        public override bool Delete(vRoles role)
        {
            return rl.Delete(role);
        }
    }
}
