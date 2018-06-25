using Microsoft.AspNetCore.Http;
using NetCoreDirectoryServices.Extensions;
using NetCoreDirectoryServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDirectoryServices.Infrastructure
{
    public class UserManager
    {
        public User CurrentUser { get; set; }
        public bool Initialized { get; set; }

        public UserManager() { }

        public async Task Create(HttpContext context)
        {
            var userPrincipal = await context.User.Identity.GetUserPrincipal();
            CurrentUser = userPrincipal.ToUserModel();
            Initialized = true;
        }

        public void Dispose()
        {
            CurrentUser = new User();
            Initialized = false;
        }
    }
}
