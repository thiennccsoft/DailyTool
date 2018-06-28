using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTValueObjects;
using DTControllers.Controllers;

namespace DailyTool.Controllers
{
    [Route("nguoi-dung/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //GET: api/User
       [HttpGet]
        public IEnumerable<vUser> Get()
        {
            UserControllers uControl = new UserControllers();
            var listU = uControl.Getall();
            return listU;
        }
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
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
