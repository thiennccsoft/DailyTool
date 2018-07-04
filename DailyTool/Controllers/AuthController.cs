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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
namespace DailyTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        UserDTcontroller controller = new UserDTcontroller();
        RoleDTcotroller role = new RoleDTcotroller();
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
        [HttpPost("token")]
        public IActionResult Token([FromBody] LoginViewModel model)
        {
            vUsers user = new vUsers
            {
                UserName = model.UserName,
                PassWord = model.PassWord
            };
            var userCheck = controller.CheckLogin(user);
            //var header = Request.Headers["Authorization"];
            //if (header.ToString().StartsWith("Basic"))
            //{
            //    var credValue = header.ToString().Substring("Basic ".Length).Trim();
            //    var usernameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));
            //    var usernameAndPass = usernameAndPassenc.Split(":");
            //    //check database
            //    //if(usernameAndPass[0] == "ducanh059@gmail.com" && usernameAndPass[1] == "ducanh97")
                
            //}
            
            if (userCheck != null)
            {
                int dt = controller.getUserByUserName(user.UserName).RoleId;
                string name = role.GetbyId(dt).RoleName;

                var claimsdata = new[] 
                {
                    new Claim(name, dt.ToString()),
                    new Claim(ClaimTypes.Role,"Admin","Employee")
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Anhzxcjjqiuvqinqmjahduuduuduudullllllllllllllllllfllflflff"));
                var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                var token = new JwtSecurityToken(
                    issuer: "mysite.com",
                    audience: "mysite.com",
                    expires: DateTime.Now.AddMinutes(5),
                    claims: claimsdata,
                    signingCredentials: signInCred
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(tokenString);
            }
            else
            return BadRequest("Wrong");
        }
    }
}