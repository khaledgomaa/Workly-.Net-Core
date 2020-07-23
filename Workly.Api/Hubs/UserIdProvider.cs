using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workly.Domain;

namespace Workly.Api.Hubs
{
    public class UserIdProvider : ICustomIdProvider
    {
        private readonly UserManager<ApplicationUser> userManager;
        public UserIdProvider(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public string GetUserId(IRequest request)
        {
            var userId = userManager.FindByNameAsync(request.User.Identity.Name);
            return userId.Id.ToString();
        }
    }
}
