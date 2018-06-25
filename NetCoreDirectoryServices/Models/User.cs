using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDirectoryServices.Models
{
    public class User
    {
        public Guid Guid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
