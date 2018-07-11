using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyTool.Auth
{
    public class AuthenRequirement : IAuthorizationRequirement
    {
        public int RoleId { set; get; }
        public AuthenRequirement(int roleId)
        {
            RoleId = roleId;
        }
    }
}
