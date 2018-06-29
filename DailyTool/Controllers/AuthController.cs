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
using Microsoft.AspNetCore.Authorization;

namespace DailyTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        UserControllers controller;
        private readonly IMapper _mapper;
        public AuthController(IMapper mapper)
        {
             controller= new UserControllers();
            _mapper = mapper;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            vUser user = new vUser
            {
                UserName = model.UserName,
                PassWord = model.PassWord
            };
            var userCheck= controller.CheckLogin(user);
            return new OkObjectResult(userCheck);
        }

        //tested
        [HttpPost("Registration")]
        public IActionResult Registration([FromBody] vUser vUser)
        {
            if (controller.Insert(vUser))
                return new OkObjectResult("Account success");
            else return new OkObjectResult("Failed");
        }
    }
}