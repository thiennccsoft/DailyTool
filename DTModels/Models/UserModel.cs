using System;
using System.Collections.Generic;
using System.Text;
using DTModels.BaseModels;
using DTModels.Entities;
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
            int rc = 0;
            var listUser = from t in (db.Users.OrderBy(x => x.UserName).Distinct().ToList())
                           select new
                           {
                               RowNumber = ++rc,
                               t.UserId,
                               t.UserName,
                               t.PassWord,
                               t.Email,
                               t.Created_At,
                               t.ReportReciver,
                               t.RoleId
                           };
            var listab = from i in listUser
                         where i.RowNumber > index && i.RowNumber <= (index + size)
                         select new
                         {
                             i.UserId,
                             i.UserName,
                             i.PassWord,
                             i.Email,
                             i.Created_At,
                             i.ReportReciver,
                             i.RoleId
                         };
           // var listUser1 = from t in (db.Users.OrderBy(x => x.UserName).ToList())select t;
            List<vUser> listU = new List<vUser>();
            foreach (var item in listUser)
            {
                vUser user = new vUser();
                user.UserId = item.UserId;
                user.UserName = item.UserName;
                user.PassWord = item.PassWord;
                user.Email = item.Email;
                user.CreateAt = item.Created_At;
                user.ReportReceiver = item.ReportReciver;
                user.RoleId = item.RoleId;

                listU.Add(user);
            }
            return listU;
        }       
        public override vUser Checklogin(vUser user)
        {
            vUser userNew = new vUser();
            var userCheck = db.Users.ToList().Where(x => x.UserName == user.UserName && x.PassWord == user.PassWord).FirstOrDefault();
            if (userCheck != null)
            {
                userNew.UserId = userCheck.UserId;
                userNew.UserName = userCheck.UserName;
                userNew.PassWord = userCheck.PassWord;
                userNew.Email = userCheck.Email;
                userNew.CreateAt = DateTime.Now.Date;
                userNew.ReportReceiver = userCheck.ReportReciver;
                userNew.RoleId = userCheck.RoleId;
                return userNew;
            }
            return userNew;
        }
        public override List<vUser> Getbypaging(int PageIndex, int PageSize, string yeucau)
        {
            return base.Getbypaging(PageIndex, PageSize, yeucau);
        }
        //use for Admin
        public override bool Insert(vUser user)
        {
            Users us = new Users();
            us.UserId = user.UserId;
            us.UserName = user.UserName;
            us.PassWord = user.PassWord;
            us.Email = user.Email;
            us.Created_At = user.CreateAt;
            us.ReportReciver = user.ReportReceiver;
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
        //use for user
        public override bool CreateUser(vUser user)
        {
            Users us = new Users();
            us.UserId = user.UserId;
            us.UserName = user.UserName;
            us.PassWord = user.PassWord;
            us.Email = user.Email;
            us.Created_At =DateTime.Now.Date;
            us.ReportReciver = user.ReportReceiver;
            us.RoleId =2;//role for user
            db.Users.Add(us);
            db.SaveChanges();
            return true;
        }
        public override bool Update(vUser vUser)
        {
            var user = db.Users.ToList().Where(x => x.UserId == vUser.UserId).FirstOrDefault();
            user.UserName = vUser.UserName;
            user.PassWord = vUser.PassWord;
            user.Email = vUser.Email;
            user.ReportReciver = vUser.ReportReceiver;
            user.RoleId = vUser.RoleId;

            db.Users.Attach(user);
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public override bool Delete(vUser user)
        {
           var userDelete= db.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();
            db.Users.Remove(userDelete);
            return true;
        }
    }
}
