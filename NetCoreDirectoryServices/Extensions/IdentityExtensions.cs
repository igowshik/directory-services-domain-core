using Microsoft.AspNetCore.Builder;
using NetCoreDirectoryServices.Infrastructure;
using NetCoreDirectoryServices.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDirectoryServices.Extensions
{
    public static class IdentityExtensions
    {
        public static IApplicationBuilder UseUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserMiddleware>();
        }

        public static User ToUserModel(this UserPrincipal principal)
        {
            return new User
            {
                Guid = principal.Guid.Value,
                Email = principal.UserPrincipalName,
                Username = principal.DisplayName
            };
        }
    }
}
