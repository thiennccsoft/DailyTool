using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTBLL.Controllers;
using DTValueObjects;
using DTValueObjects.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserDTcontroller controller = new UserDTcontroller();
        [HttpPost]
        public IActionResult Post([FromBody] RegisterViewModel model)
        {
            vUsers vUser = new vUsers
            {
                UserName = model.UserName,
                PassWord = model.PassWord,
                ReportReciver = model.ReportReceiver,
                Email = model.Email,
                RoleId = 2,
                Created_At=DateTime.Now.Date
            };
            if (controller.Insert(vUser))
                return new OkObjectResult("Account success");
            else return new OkObjectResult("Failed");
        }
        [HttpPut]
        public vUsers Put([FromBody] vUsers vUser)
        {
            controller.Update(vUser);
            return vUser;
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] vUsers vUser)
        {
            if (controller.Delete(vUser))
                return new OkObjectResult("deleted");
            else return new OkObjectResult("failed");
        }
    }
}