using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTValueObject;
using DTModels.DAL;
using DailyTool.ViewModels;
using DTModels.Database;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using DailyTool.Helpers;

namespace DailyTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {        
        private readonly IMapper _mapper;
        private readonly PlanDailyContext db=new PlanDailyContext();
        public AccountController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]RegistrationViewModel model)
        {
            var user = _mapper.Map<Users>(model);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //await db.Users.AddAsync(user);
            await db.Users.AddAsync(new Users
            {
                UserName = model.UserName,
                PassWord = model.Password,
                Email = model.Email,
                RoleId = model.RoleId,
                CreateAt = model.CreateAt
            });
            await db.SaveChangesAsync();
            return new OkObjectResult("Đăng ký thành công");
        }
        //[HttpPost]
        //public Users Insert(Users user)
        //{            
        //    db.Users.Add(user);
        //    db.SaveChanges();
        //    return user;
        //}
    }
}