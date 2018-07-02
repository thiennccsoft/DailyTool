using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using DTControllers.BaseControllers;
using DTModels.Models;
using DTValueObjects;
using DTControllers.Controllers;


namespace DailyTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        public ArrayList distribute_user()
        {
            ArrayList distribute = new ArrayList();
            UserControllers u = new UserControllers();
            List<vUser> users = u.Getall();
            List<vUser> manager = new List<vUser>();
            foreach(var item in users)
            {
                if (item.ReportReceiver == null)
                {
                    manager.Add(item);
                }
            }
            distribute.Add(manager);
            foreach (var item in manager)
            {
                List<vUser> use = new List<vUser>();
                foreach(var i in users)
                {
                {
                    if (item.UserId == i.ReportReceiver)
                    {
                        use.Add(i);
                    }
                }
                distribute.Add(use);
            }
            
            return distribute;
        }

     






    }
}