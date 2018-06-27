using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTModels.Database;
using Microsoft.AspNetCore.Identity;
using DTValueObject;
using Microsoft.EntityFrameworkCore;

namespace DailyTool.Controllers
{
    [Authorize(Policy = "Customer")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly PlanDailyContext _appDbContext;

        public DashboardController(UserManager<VUser> userManager, PlanDailyContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            // retrieve the user info
            //HttpContext.User
            var userId = _caller.Claims.Single(c => c.Type == "id");
            var customer = await _appDbContext.Customers.Include(c => c.Identity).SingleAsync(c => c.Identity.UserId == Guid.Parse(userId.Value));

            return new OkObjectResult(new
            {
                Message = "This is secure API and user data!",
                customer.Identity.UserName,
                customer.Identity.PassWord,
                customer.Identity.Email,
                customer.Identity.RoleId,
            });
        }
    }
}