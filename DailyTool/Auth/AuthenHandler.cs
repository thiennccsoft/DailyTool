using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DailyTool.Auth
{
    public class AuthenHandler: AuthorizationHandler<AuthenRequirement >
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthenRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Name &&
                                        c.Issuer == "http://contoso.com"))
            {
                //TODO: Use the following if targeting a version of
                //.NET Framework older than 4.6:
                //      return Task.FromResult(0);
                return Task.CompletedTask;
            }

            var userName = context.User.FindFirst(c => c.Type == ClaimTypes.Name && c.Issuer == "http://contoso.com").Value;

            
            //if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
            //{
            //    calculatedAge--;
            //}

            //if (calculatedAge >= requirement.RoleId)
            //{
            //    context.Succeed(requirement);
            //}

            //TODO: Use the following if targeting a version of
            //.NET Framework older than 4.6:
            //      return Task.FromResult(0);
            return Task.CompletedTask;
        }
    }
}
