using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Workly.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public virtual User User { get; set; }

        public virtual Agent Agent { get; set; }
    }
}
