using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authentication;

namespace Grpc.ProductManagement.Authorization
{
    public class PermissionAuthorizeAttribute : TypeFilterAttribute
    {
        public PermissionAuthorizeAttribute(params string[] permissions) : base(typeof(PermissionAuthorizeExecuteAttribute))
        {
            Arguments = new[] { new PermissionAuthorizationRequirement(permissions) };
        }

        private sealed class PermissionAuthorizeExecuteAttribute
          : Attribute, IAsyncResourceFilter
        {
            private readonly IAuthorizationService AuthorizationService;
            private readonly PermissionAuthorizationRequirement RequiredPermissions;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public PermissionAuthorizeExecuteAttribute(
                  PermissionAuthorizationRequirement requiredPermissions,
                  IAuthorizationService authorizationService,
                  IHttpContextAccessor httpContextAccessor)
            {
                RequiredPermissions = requiredPermissions;
                AuthorizationService = authorizationService;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
            {
                var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                var permission = RequiredPermissions;
                if (string.IsNullOrEmpty(accessToken))
                {
                    return;
                }
                //var authenticateInfo = await HttpContext.Authentication.GetAuthenticateInfoAsync("Bearer");
                //var result = 
                //if (!authResult.Succeeded)
                //{
                //    context.Result = new ChallengeResult();
                //    return;
                //}
                await next?.Invoke();
            }
        }
    }
}
