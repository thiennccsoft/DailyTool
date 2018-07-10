﻿using System;
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
        public vUsers CheckLogin(string username, string password)
        {
            var kq = db.Users.ToList().Find(x => x.UserName == username && x.PassWord == password);
            if(kq!=null)
            {
                vUsers nuser = new vUsers();
                nuser = changetovUser(kq);
                return nuser;
            }
            return null;
        }

        public vUsers GetByEmail(string email)
        {
            var user = db.Users.Where(x => x.Email == email).FirstOrDefault();
            if (user != null)
            {
                vUsers vUser = new vUsers();
                vUser = changetovUser(user);
                return vUser;
            }
            return null;
        }

        public vUsers ChangePassword(string userName,string oldPass,string newPass)
        {
            var user = db.Users.Where(x => x.UserName == userName && x.PassWord==oldPass).FirstOrDefault();
            if(user!=null)
            {
                user.PassWord = newPass;                
                vUsers nuser = new vUsers();
                nuser = changetovUser(user);
                db.SaveChanges();
                return nuser;
            }
            return null;
        }
        public vUsers GetbyId(Guid userid)
        {
            var kq = db.Users.ToList().Find(x => x.UserId == userid);
            vUsers nuser = new vUsers();
            nuser = changetovUser(kq);
            return nuser;
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

        public bool checkEmail(string email)
        {
            try
            {
                var a = db.Users.Single(x => x.Email == email); return true;
            }
            catch {
            return false;
            }
        }
    }
}