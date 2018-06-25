using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDirectoryServices.Infrastructure
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _next;

        public UserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, UserManager userManager)
        {
            if (!(userManager.Initialized))
            {
                await userManager.Create(httpContext);
            }

            await _next(httpContext);

            userManager.Dispose();
        }
    }
}
