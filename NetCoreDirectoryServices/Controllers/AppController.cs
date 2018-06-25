using Microsoft.AspNetCore.Mvc;
using NetCoreDirectoryServices.Extensions;
using NetCoreDirectoryServices.Infrastructure;
using NetCoreDirectoryServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDirectoryServices.Controllers
{
    [Route("api/[controller]")]
    public class AppController : Controller
    {
        private UserManager manager;

        public AppController(UserManager manager)
        {
            this.manager = manager;
        }

        [HttpGet("[action]")]
        public User GetCurrentUser() => manager.CurrentUser;

        [HttpGet("[action]/{filter}")]
        public async Task<List<User>> FilterUsers([FromRoute]string filter) => await filter.FindDomainUser();

    }
}
