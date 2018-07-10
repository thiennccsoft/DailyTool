using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DTBLL.Controllers;
using DTValueObjects;
using DTValueObjects.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DailyTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        UserDTcontroller controller = new UserDTcontroller();
        RoleDTcotroller roleDT = new RoleDTcotroller();
        MailDTController mailDT = new MailDTController();
        private IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginViewModel login)
        {
            IActionResult response = Unauthorized();
            var userCheck = controller.CheckLogin(login.UserName, login.PassWord);
            if (userCheck != null)
            {
                var tokenString = BuildToken(userCheck);
                response = Ok(new { token = tokenString });      
                return response;
            }
            else return new OkObjectResult("Tài khoản không đúng hoặc mật khẩu");
        }
        
        //create token
        private string BuildToken(vUsers user)
        {
            var nameRole = roleDT.GetbyId(user.RoleId);
            var claimData = new[] { new Claim(nameRole.RoleName, user.RoleId.ToString()) };
            //
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claimData,
              expires: DateTime.Now.AddHours(1),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        [HttpPost("create-user"), Authorize(Policy ="Admin")]
        public IActionResult CreateUser(vUsers vUser)
        {
            vUser.Created_At = DateTime.Now.Date;
            
            if (controller.Insert(vUser))
                return new OkObjectResult("Create user success");
            else return BadRequest();
        }
        //change password
        [Authorize(Policy = "Customer")]
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody]ChangePasswordModel changModel )
        {
            if(!ModelState.IsValid)
            {
                return new OkObjectResult("Failed");      
            }
            vUsers user = new vUsers();
            var userCheck = controller.ChangePass(changModel.UserName, changModel.PassWord, changModel.NewPassWord);
            if (userCheck!=null)
            {
                return new OkObjectResult(userCheck);
            }
            return new OkObjectResult("Failed");
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody]EmailViewModel viewModel)
        {
            if(controller.checkEmail(viewModel.Email))
            {
                var u = System.IO.File.ReadAllText("forgotpassword.html");
                //send mail
                u.Replace("{{email}}", viewModel.Email);
                mailDT.SendEmail(controller.GetByEmail(viewModel.Email),u);
                return new OkObjectResult("da gui mail toi " + viewModel.Email);
            }
            
            return new OkObjectResult("khong tim thay mail");
        }
        [HttpPost("changepassword/{email}")]
        public IActionResult Change(string email, [FromBody]ChangePasswordModel changModel)
        {
            if (!ModelState.IsValid)
            {
                return new OkObjectResult("Failed");
            }
            vUsers user = new vUsers();
            var userCheck = controller.ChangePass(changModel.UserName, changModel.PassWord, changModel.NewPassWord);
            if (userCheck != null)
            {
                return new OkObjectResult(userCheck);
            }
            return new OkObjectResult("Failed");
        }
    }
}