using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTBLL.Controllers;
using DTValueObjects;


namespace DailyTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        [HttpPost]//date lay ngay xem bao cao.
        public IActionResult Getdate(DateTime date) //Chon ngay de xem thong ke danh sach, tat ca nhan vien
        {
            User_ToSend list_User = new User_ToSend();
            list_User.Getdata(date);
            UserName_ToSend list_userName = new UserName_ToSend();//tra ve
            GetbyID getbyID = new GetbyID();
            foreach(var item in list_User.Users_NotSend)
            {
                list_userName.UserName_NotSend.Add(getbyID.GetById(item));
            }
            foreach(var item in list_User.Users_Sent)
            {
                list_userName.UserName_Sent.Add(getbyID.GetById(item.UserId));
            }
            //
            //Xem theo cac team, gui thong bao cho quan li tung team
            Teams teams = new Teams();
            List<Teams> list_teams = teams.DivideTeams();
            List<Report_ToEachManager> report_ToEachManagers = new List<Report_ToEachManager>();//danh sach bao cao gui ve cho tung` manager
            foreach(var item in list_teams)
            {
                Report_ToEachManager _ToEachManager = new Report_ToEachManager();
                _ToEachManager.Manager = item.Manager;
                foreach(var i in item.Member)
                {
                    foreach(var j in list_User.Users_Sent)
                    {
                        if (j.UserId == i.UserId)
                        {
                            _ToEachManager.Content_ForManager.Users_Sent.Add(j);

                        }
                        else _ToEachManager.Content_ForManager.Users_Sent.Add(j);
                    }
                }
                report_ToEachManagers.Add(_ToEachManager);
            }

                       
            return null;
        }

        public class Report_ToEachManager
        {
            public vUsers Manager { get; set; }
            public User_ToSend Content_ForManager { get; set; }
        }
      

        
        public class UserName_ToSend                //Hien thi ten thay cho id
        {
            public List<string> UserName_Sent { get; set; }
            public List<string> UserName_NotSend { get; set; }
           
        }
        public class GetbyID
        {
            public string GetById(Guid Id)
            {
                UserDTcontroller userDTcontroller = new UserDTcontroller();
                List<vUsers> AllUser = userDTcontroller.GetAll();
                string username1 = "";
                foreach (var item in AllUser)
                {
                    if (Id == item.UserId)
                    {
                        username1 = item.UserName;
                    }
                }
                return username1;
            }
        }
        public class UserSent
        {
            public Guid UserId { get; set; }
            public vReports UserReport { get; set; }  
            
        }
       
    
        
        public class User_ToSend
        {
            public List<UserSent> Users_Sent { get; set; }
            public List<Guid> Users_NotSend { get; set; }

            public void Getdata(DateTime Date)// lay danh sach nguoi gui va chua gui trong ngay 
            {
                string date = Date.ToString("dd-MM-yyyy");
                ReportDTcontroller reportDTcontroller = new ReportDTcontroller();
                List<vReports> reports = reportDTcontroller.GetAll();
                List<vReports> report_sent = new List<vReports>();
                foreach (var item in reports)
                {
                    string _date = item.Created_At.ToString("dd-MM-yyyy");
                    if (date == _date)
                    {
                        report_sent.Add(item);
                    }
                }
                UserReportDTcontroller userReportDTcontroller = new UserReportDTcontroller();
                List<vUserReports> vUserReports = userReportDTcontroller.GetAll();
                foreach (var item in vUserReports)
                {
                    foreach (var i in report_sent)
                    {
                        if (i.ReportId == item.ReportId)
                        {
                            UserSent userSent = new UserSent();
                            userSent.UserId = item.UserId;
                            userSent.UserReport = i;
                            Users_Sent.Add(userSent);// Add thong tin nguoi gui va bao cao cua nhung nguoi da gui bao cao
                        }
                    }
                }
                UserDTcontroller userDTcontroller = new UserDTcontroller();
                List<vUsers> vUsers = userDTcontroller.GetAll();
                foreach (var item in vUsers)
                {
                    foreach (var i in Users_Sent)
                    {
                        if (item.UserId == i.UserId) { }
                        else Users_NotSend.Add(item.UserId);// Danh sach Id nguoi chua gui
                    }
                }
            }
        }
        public class Teams// cac nhom co nguoi quan li khac nhau
        {

            public vUsers Manager { get; set; }
            public List<vUsers> Member { get; set; }
            public List<Teams> DivideTeams()// Chia nhomm voi moi nguoi quan li 1 nhom
            {
                List<Teams> teams = new List<Teams>();
                UserDTcontroller userDTcontroller = new UserDTcontroller();
                List<vUsers> vUsers = userDTcontroller.GetAll();
                List<vUsers> List_Manager = new List<vUsers>();
                foreach (var item in vUsers)
                {
                    if (item.ReportReciver == null)// Khong co nguoi nhan bao cao la quan li cao nhat
                    {
                        Teams team = new Teams();
                        team.Manager = item;
                        List_Manager.Add(item);
                        foreach (var i in vUsers)
                        {
                            if (i.ReportReciver == item.UserId)
                            {
                                Member.Add(i);
                            }
                        }
                        teams.Add(team);
                    }
                    else
                    {
                        int exist = 0;//Kiem tra nguoi nhan bao cao co ton tai trong danh sach Manager khong
                        foreach (var m in List_Manager)
                        {
                            if (item.ReportReciver == m.UserId)
                            {
                                exist = 1;
                            }
                        }
                        if (exist == 0)//Khong ton tai
                        {
                            foreach (var k in vUsers)
                            {
                                if (k.UserId == item.ReportReciver)
                                {
                                    List_Manager.Add(k);
                                    // tao nhom moi
                                    Teams team1 = new Teams();
                                    team1.Manager = k;
                                    foreach (var l in vUsers)
                                    {
                                        if (l.ReportReciver == k.UserId)
                                        {
                                            team1.Member.Add(l);
                                        }
                                    }
                                    teams.Add(team1);

                                }
                            }
                        }
                    }

                }
                return teams;// Ket qua chia nhom: 1 List

            }

        }
    }
}