using System;
using System.Collections.Generic;
using System.Text;
using DTModels.BaseDAL;
using DTValueObject;
using DTModels.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace DTModels.DAL
{
    public class UserDAL:BaseUsers<VUser>
    {
        PlanDailyContext dbContext;
        public UserDAL()
        {
            dbContext = new PlanDailyContext();
        }
        
        public override VUser Checklogin(VUser user)
        {
            var list = dbContext.Users.FromSql("User_Select_All ");
            VUser vUser = new VUser();
            var userCheck= list.Where(x=>x.UserName==user.UserName && x.PassWord==user.PassWord).FirstOrDefault();
            if (userCheck != null)
            {
                vUser.UserId = userCheck.UserId;
                vUser.UserName = userCheck.UserName;
                vUser.PassWord = userCheck.PassWord;
                vUser.Email = userCheck.Email;
                vUser.CreateAt = userCheck.CreateAt;
                vUser.ReportReceiver = userCheck.ReportReceiver;
                vUser.RoleId = userCheck.RoleId;
                return vUser;
            }
            return vUser;
        }
    }
}
