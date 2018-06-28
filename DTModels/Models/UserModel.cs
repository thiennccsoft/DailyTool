using System;
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
            int rc = 0;
            var listUser = from t in (db.Users.OrderBy(x => x.UserName).Distinct().ToList())
                           select new
                           {
                               RowNumber = ++ rc ,
                               t.UserId,
                               t.UserName,
                               t.PassWord,
                               t.Email,
                               t.CreateAt,
                               t.ReportReceiver,
                               t.RoleId
                           };
            var listab = from i in listUser
                         where i.RowNumber > index && i.RowNumber <=(index + size)
                         select new {
                             i.UserId,
                             i.UserName,
                             i.PassWord,
                             i.Email,
                             i.CreateAt,
                             i.ReportReceiver,
                             i.RoleId
                         };
            List<vUser> listU = new List<vUser>();
            foreach (var item in listab)
            {
                vUser user = new vUser();
                user.UserId = item.UserId;
                user.UserName = item.UserName;
                user.PassWord = item.PassWord;
                user.Email = item.Email;
                user.CreateAt = item.CreateAt;
                user.ReportReceiver = item.ReportReceiver;
                user.RoleId = item.RoleId;

                listU.Add(user);
            }
            return listU;
        }
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
        }
    }
}
