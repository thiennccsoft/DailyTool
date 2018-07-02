using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Text;
using DTModels.BaseModels;
using DTModels.Database;
using DTValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.SqlClient;

namespace DTModels.Models
{
    public class UserModel:BaseUser<vUser>
    {
        public override List<vUser> Getall()
        {
            int index = 0;
            int size = 10;
=======
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
>>>>>>> master
            int rc = 0;
            var listUser = from t in (db.Users.OrderBy(x => x.UserName).Distinct().ToList())
                           select new
                           {
<<<<<<< HEAD
                               RowNumber = ++ rc ,
=======
                               RowNumber = ++rc,
>>>>>>> master
                               t.UserId,
                               t.UserName,
                               t.PassWord,
                               t.Email,
<<<<<<< HEAD
                               t.CreateAt,
                               t.ReportReceiver,
                               t.RoleId
                           };
            var listab = from i in listUser
                         where i.RowNumber > index && i.RowNumber <=(index + size)
                         select new {
=======
                               t.Created_At,
                               t.ReportReciver,
                               t.RoleId
                           };
            var listab = from i in listUser
                         where i.RowNumber > pageIndex && i.RowNumber <= (pageIndex + pageSize)
                         select new
                         {
>>>>>>> master
                             i.UserId,
                             i.UserName,
                             i.PassWord,
                             i.Email,
<<<<<<< HEAD
                             i.CreateAt,
                             i.ReportReceiver,
                             i.RoleId
                         };
            List<vUser> listU = new List<vUser>();
            foreach (var item in listab)
            {
                vUser user = new vUser();
=======
                             i.Created_At,
                             i.ReportReciver,
                             i.RoleId
                         };
            List<vUsers> listU = new List<vUsers>();
            foreach (var item in listab)
            {
                vUsers user = new vUsers();
>>>>>>> master
                user.UserId = item.UserId;
                user.UserName = item.UserName;
                user.PassWord = item.PassWord;
                user.Email = item.Email;
<<<<<<< HEAD
                user.CreateAt = item.CreateAt;
                user.ReportReceiver = item.ReportReceiver;
=======
                user.Created_At = item.Created_At;
                user.ReportReciver = item.ReportReciver;
>>>>>>> master
                user.RoleId = item.RoleId;

                listU.Add(user);
            }
            return listU;
        }
<<<<<<< HEAD
        public override List<vUser> Getbypaging(int PageIndex, int PageSize, string yeucau)
        {
            return base.Getbypaging(PageIndex, PageSize, yeucau);
        }
        public override bool Insert(vUser user)
        {
            Users us = new Users();
            us.UserId = user.UserId;
            us.UserName = user.UserName;
            us.PassWord = user.PassWord;
            us.Email = user.Email;
            us.CreateAt = user.CreateAt;
            us.ReportReceiver = user.ReportReceiver;
            us.RoleId = user.RoleId;
            db.Users.Add(us);
            db.SaveChanges();
            //var param1 = new SqlParameter("@userid", user.UserId);
            //var param2 = new SqlParameter("@username", user.UserName);
            //var param3 = new SqlParameter("@password ", user.PassWord);
            //var param4 = new SqlParameter("@email ", user.PassWord);
            //var param5 = new SqlParameter("@CreateAt ", user.PassWord);
            //var param6 = new SqlParameter("@ReportReceiver ", user.ReportReceiver);
            //var param7 = new SqlParameter("@roleid ", user.RoleId);
            //db.Users.FromSql("User_Insert @userid, @username, @password, @email, @CreateAt, @ReportReceiver, @roleid", parameters: new[] { user.UserId, user.UserName, user.PassWord, user.PassWord, user.PassWord, user.ReportReceiver, user.RoleId });
            return true;
        }
        public override bool Update(vUser user)
        {
            Users us = new Users();
            db.Update<Users>(us);

            db.Users.Attach(us);
            db.Entry(us).State = EntityState.Modified;
            db.SaveChanges();
            return base.Update(user);
        }
        public override bool Delete(vUser user)
        {
            return base.Delete(user);
=======
        public override vUsers CheckLogin(vUsers user)
        {
            var kq = db.Users.ToList().Find(x => x.UserName == user.UserName && x.PassWord == user.PassWord);
            vUsers nuser = new vUsers();
            nuser = changetovUser(kq);

            return nuser;
        }
        public override vUsers GetbyId(vUsers user)
        {
            var kq = db.Users.ToList().Find(x => x.UserId == user.UserId);
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
            db.Attach(nuser);
            nuser = changetoUser(user);
            db.Entry(nuser).State = EntityState.Modified;
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
>>>>>>> master
        }
    }
}
