using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DTModels.BaseModels;
using DTValueObjects;
using DTModels.Database;
using Microsoft.EntityFrameworkCore;

namespace DTModels.Models
{
    public class UserModel : BaseUser<vUsers>
    {
        public override List<vUsers> GetAll()
        {
            List<vUsers> listU = new List<vUsers>();
            var listuser = db.Users;
            foreach (var item in listuser)
            {
                vUsers user = new vUsers();
                user = changetovUser(item);

                listU.Add(user);
            }
            return listU;
        }
        public override List<vUsers> GetbyPaging(int pageIndex, int pageSize)
        {
            //int rc = 0;
            var listab = db.Users.OrderBy(x => x.UserName).Skip(pageIndex * pageSize).Take(pageSize).ToList();
            //var listUser = from t in (db.Users.OrderBy(x => x.UserName).Distinct().ToList())
            //               select new
            //               {
            //                   RowNumber = ++rc,
            //                   t.UserId,
            //                   t.UserName,
            //                   t.PassWord,
            //                   t.Email,
            //                   t.Created_At,
            //                   t.ReportReciver,
            //                   t.RoleId
            //               };
            //var listab = from i in listUser
            //             where i.RowNumber > pageIndex && i.RowNumber <= (pageIndex * pageSize)
            //             select new
            //             {
            //                 i.UserId,
            //                 i.UserName,
            //                 i.PassWord,
            //                 i.Email,
            //                 i.Created_At,
            //                 i.ReportReciver,
            //                 i.RoleId
            //             };
            List<vUsers> listU = new List<vUsers>();
            foreach (var item in listab)
            {
                vUsers user = new vUsers();
                user.UserId = item.UserId;
                user.UserName = item.UserName;
                user.PassWord = item.PassWord;
                user.Email = item.Email;
                user.Created_At = item.Created_At;
                user.ReportReciver = item.ReportReciver;
                user.RoleId = item.RoleId;

                listU.Add(user);
            }
            return listU;
        }
        public  vUsers CheckLogin(string username, string password)
        {
            var kq = db.Users.ToList().Find(x => x.UserName == username && x.PassWord == password);
            vUsers nuser = new vUsers();
            nuser = changetovUser(kq);

            return nuser;
        }
        public  vUsers GetbyId(Guid userid)
        {
            var kq = db.Users.ToList().Find(x => x.UserId == userid);
            vUsers nuser = new vUsers();
            nuser = changetovUser(kq);

            return nuser;
        }
        public override bool Insert(vUsers user)
        {

            Users nuser = changetoUser(user);
            db.Users.Add(nuser);
            db.SaveChanges();
            return true;
        }
        public override bool Update(vUsers user)
        {
            Users nuser = db.Users.ToList().Find(x => x.UserId == user.UserId);
            //db.Attach(nuser);
            //nuser = changetoUser(user);
            //db.Entry(nuser).State = EntityState.Modified;
            nuser.UserName = user.UserName;
            nuser.PassWord = user.PassWord;
            nuser.Email = user.Email;
            nuser.ReportReciver = user.ReportReciver;
            nuser.RoleId = user.RoleId;
            db.SaveChanges();

            return true;
        }
        public override bool Delete(vUsers user)
        {
            Users nuser = changetoUser(user);
            db.Users.Remove(nuser);
            db.SaveChanges();
            return true;
        }
        public Users changetoUser(vUsers vuser)
        {
            Users nuser = new Users();
            nuser.UserId = vuser.UserId;
            nuser.UserName = vuser.UserName;
            nuser.PassWord = vuser.PassWord;
            nuser.Email = vuser.Email;
            nuser.Created_At = vuser.Created_At;
            nuser.ReportReciver = vuser.ReportReciver;
            nuser.RoleId = vuser.RoleId;
            return nuser;
        }
        public vUsers changetovUser(Users user)
        {
            vUsers nuser = new vUsers();
            nuser.UserId = user.UserId;
            nuser.UserName = user.UserName;
            nuser.PassWord = user.PassWord;
            nuser.Email = user.Email;
            nuser.Created_At = user.Created_At;
            nuser.ReportReciver = user.ReportReciver;
            nuser.RoleId = user.RoleId;
            return nuser;
        }

        public List<vUsers> getUsersNotReport()
        {
            IEnumerable<Users> lst = db.Users.Where(a => !db.User_Reports.Any(r => r.UserId == a.UserId));
            List<vUsers> result = new List<vUsers>();
            foreach (Users item in lst)
            {
                result.Add(changetovUser(item));
            }
            return result;
        }

        public List<vUsers> getAdmins()
        {
            var lst = from users in db.Users
                      from roles in db.Roles
                      where users.RoleId == roles.RoleId && roles.RoleName == "Admin"
                      select users;
            List<vUsers> result = new List<vUsers>();
            foreach (var item in lst)
            {
                result.Add(changetovUser(item));
            }
            return result;
        }
    }
}
