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
    public class AuthController : ControllerBase
    {
        UserDTcontroller controller = new UserDTcontroller();
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            vUsers user = new vUsers
            {
                UserName = model.UserName,
                PassWord = model.PassWord
            };
            var userCheck = controller.CheckLogin(user);
            return new OkObjectResult(userCheck);
        }

    }
}