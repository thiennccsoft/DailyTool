using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DTValueObject;
using DTModels.DAL;
using Microsoft.AspNetCore.Identity;
using DailyTool.Auth;
using DailyTool.Models;
using DailyTool.Helpers;
using Newtonsoft.Json;
using System.Security.Claims;
using DailyTool.ViewModels;
using AutoMapper;
using DTModels.Database;

namespace DailyTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly PlanDailyContext db = new PlanDailyContext();
        private UserDAL userDAL = new UserDAL();
        private readonly UserManager<VUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IMapper _mapper;
        //contructor
        public AuthController(IJwtFactory jwtFactory, JwtIssuerOptions jwtIssuerOptions, UserManager<VUser> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtIssuerOptions;
            _jwtOptions = jwtIssuerOptions;
            _mapper = mapper;
        }
        //// POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CredentialsViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            var identity = await GetClaimsIdentity(credentials.UserName, credentials.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }
            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return new OkObjectResult(jwt);
        }
        [HttpGet]
        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.UserId));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}