using System;
using System.Collections.Generic;
using System.Text;
using DTModels.BaseModels;
using DTValueObjects;
using DTModels.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DTModels.Models
{
    public class RoleModel:BaseRole<vRoles>
    {
        public override List<vRoles> GetAll()
        {
            List<vRoles> listR = new List<vRoles>();
            var listrole = db.Roles;
            foreach (var item in listrole)
            {
                vRoles role = new vRoles();
                role = changetovRole(item);

                listR.Add(role);
            }
            return listR;
        }
        public override bool Insert(vRoles role)
        {
            Roles nrole = changetoRole(role);
            db.Roles.Add(nrole);
            db.SaveChanges();
            return true;
        }
        public override bool Update(vRoles usroleer)
        {
            Roles nrole = db.Roles.ToList().Find(x => x.RoleId == usroleer.RoleId);
            db.Attach(nrole);
            nrole = changetoRole(usroleer);
            db.Entry(nrole).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }
        public override bool Delete(vRoles role)
        {
            Roles nrole = changetoRole(role);
            db.Roles.Remove(nrole);
            db.SaveChanges();
            return true;
        }
        public vRoles GetbyId(int roleid)
        {
            var kq = db.Roles.ToList().Find(x => x.RoleId == roleid);
            vRoles nrole = new vRoles();
            nrole = changetovRole(kq);

            return nrole;
        }
        public Roles changetoRole(vRoles vrole)
        {
            Roles nrole = new Roles();
            nrole.RoleId = vrole.RoleId;
            nrole.RoleName = vrole.RoleName;
            return nrole;
        }
        public vRoles changetovRole(Roles role)
        {
            vRoles nrole = new vRoles();
            nrole.RoleId = role.RoleId;
            nrole.RoleName = role.RoleName; ;
            
            return nrole;
        }
    }
}
