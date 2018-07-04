using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        private IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult CreateToken([FromBody]LoginViewModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);
            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });             
                return response;
            }
            else return new OkObjectResult("Tài khoản không đúng hoặc mật khẩu");
        }
        //check login
        private vUsers Authenticate(LoginViewModel model)
        {
            var userCheck = controller.CheckLogin(model.UserName,model.PassWord);
            if (userCheck != null)
                return userCheck;
            else return null;
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
              expires: DateTime.Now,
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        [HttpPost("create-user"), Authorize(Policy ="Admin")]
        public IActionResult CreateUser(vUsers vUser)
        {
            vUser.Created_At = DateTime.Now.Date;
            
            if (controller.Insert(vUser))
                return new OkObjectResult("Create user success");
            else return new OkObjectResult("Failed");
        }
        
    }
}