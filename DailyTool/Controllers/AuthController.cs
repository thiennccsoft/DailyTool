using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DTBLL.Controllers;
using DTValueObjects;
using DTValueObjects.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DailyTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        UserDTcontroller controller = new UserDTcontroller();
        RoleDTcotroller roleDT = new RoleDTcotroller();
        private readonly IConfiguration _config;
        //private readonly RoleManager<IdentityRole> _roleManager;, RoleManager<IdentityRole> roleManager

        public AuthController(IConfiguration config)
        {
            _config = config;
           // _roleManager = roleManager;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginViewModel login)
        {
            IActionResult response = Unauthorized();
            var userCheck = controller.CheckLogin(login.UserName, login.PassWord);
            if (userCheck != null)
            {
                var userRole = roleDT.GetbyId(userCheck.RoleId);
                var roleNew = new IdentityRole(userRole.RoleName);
                //await _roleManager.CreateAsync(roleNew);
                var tokenString = BuildToken(userCheck);
                response = Ok(new { token = tokenString });
                return response;
            }
            else return new OkObjectResult("Tài khoản hoặc mật khẩu không đúng");
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

        [HttpPost("create-user"), Authorize(Policy = "Admin")]
        public IActionResult CreateUser(vUsers vUser)
        {
            vUser.Created_At = DateTime.Now.Date;

            if (controller.Insert(vUser))
                return new OkObjectResult("Create user success");
            else return BadRequest();
        }
        //change password
        [Authorize(Policy = "Customer")]
        [HttpPost("changepassword/{email}")]
        public IActionResult ChangePassword(string email, [FromBody]ChangePasswordModel changModel)
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
        [HttpPost("get-code")]
        public void SendMail([FromBody]EmailViewModel Email)
        {
            var user = controller.GetByEmail(Email.Email);
            var toAddress = new MailAddress(user.Email);

            var fromAddress = new MailAddress("dohue97yp1@gmail.com");
            string pass = "dothihueyp1";
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = "Forgot password";
            message.Body = "Click in link: <a href= \"https://localhost:44342/api/auth/change-password/" + user.Email + " \">Go to link</a>";
            message.IsBodyHtml = true;

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromAddress.ToString(), pass);
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}