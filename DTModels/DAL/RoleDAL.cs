using System;
using System.Collections.Generic;
using System.Text;
using DTModels.BaseDAL;
using DTValueObject;
using DTModels.Database;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DTModels.DAL
{
    public class RoleDAL:BaseRoles<VRole>
    {
        private readonly PlanDailyContext dbContext;
        public RoleDAL()
        {
            dbContext = new PlanDailyContext();
        }
        public override List<VRole> GetAllRole()
        {
            List<VRole> listRoles = new List<VRole>();
            var list = dbContext.Roles.FromSql("Role_Select_All");
            foreach (var item in list)
            {
                VRole role = new VRole();
                role.RoleId = item.RoleId;
                role.RoleName = item.RoleName;
                listRoles.Add(role);
            }
            return listRoles;
        }
        public override bool Insert(VRole role)
        {
            role.RoleId = 4;
            role.RoleName = "Tester";
            dbContext.Roles.FromSql("Role_Insert @RoleId @RoleName",parameters:(role.RoleId,role.RoleName));
            return true;
        }
    }
}
