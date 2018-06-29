using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTValueObjects;
using DTControllers.Controllers;
using AutoMapper;
using DTValueObjects.ViewModels;

namespace DailyTool.Controllers
{
    [Route("nguoi-dung/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserControllers controller = new UserControllers();       
        //[HttpGet]
        //public IEnumerable<vUser> Get()
        //{
        //    UserControllers uControl = new UserControllers();
        //    var listU = uControl.Getall();
        //    return listU;
        //}
        // GET: api/User
        //[HttpGet]
        //public bool Post()
        //{
        //    UserControllers uControl = new UserControllers();
        //    vUser user = new vUser();
        //    user.UserId = Guid.NewGuid();
        //    user.UserName = "sport";
        //    user.PassWord = "adad";
        //    user.Email = "adad@gmail.com";
        //    user.CreateAt = DateTime.Parse("12/12/2018");
        //    user.ReportReceiver = null;
        //    user.RoleId = 1;
        //    bool kq = uControl.Insert(user);
        //    return kq;
        //}

        // GET: api/User/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/User
        //tested
        [HttpPost]
        public IActionResult Post([FromBody]RegisterViewModel model)
        {
            vUser vUser = new vUser
            {
                UserName = model.UserName,
                PassWord = model.PassWord,
                ReportReceiver = model.ReportReceiver,
                Email = model.Email
            };
            if (controller.CreateUser(vUser))
                return new OkObjectResult("Account success");
            else return new OkObjectResult("Failed");
        }
        //tested need id in url
        // PUT: api/User/5
        [HttpPut("{id}")]
        public vUser Put([FromBody] vUser vUser)
        {
            controller.Update(vUser);
            return vUser;
        }
        
    }
}
