using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using RobotStoreDataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace RobotsWebStore.Filters
{
    public class JwtAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private string[] _roles;

        public JwtAuthorizationFilter (params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key.Equals("JwtToken", StringComparison.InvariantCultureIgnoreCase));
            
            if (!ValidateToken(token.Value, _roles))
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                throw new UnauthorizedAccessException();
            }
        }

        private static bool ValidateToken(string token, string[] roles)
        {
            string username = null;

            var simplePrinciple = TokenManager.GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;

            var rolesClaim = identity.FindFirst(ClaimTypes.Role);
            if (!roles.Contains(rolesClaim.Value))
                return false;

            if (string.IsNullOrEmpty(username))
                return false;

            // More validate to check whether username exists in system

            return true;
        }

        
    }
}
