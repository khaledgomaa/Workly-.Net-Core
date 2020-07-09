using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Workly.Domain;
using Workly.Service.Interfaces;

namespace Workly.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserAgentProfileController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly IAgentManager agentManager;
        private readonly UserManager<ApplicationUser> aspUserManager;

        public UserAgentProfileController(IUserManager userManager
                                         , IAgentManager agentManager
                                         , UserManager<ApplicationUser> aspUserManager)
        {
            this.userManager = userManager;
            this.agentManager = agentManager;
            this.aspUserManager = aspUserManager;
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> UserInfo(string userName)
        {
            if (userName == null)
                return NotFound();

            var userInaspNetTable = await aspUserManager.FindByNameAsync(userName);
            if (userInaspNetTable == null)
                return NotFound();

            return Ok(userManager.GetFirstOrDefaultByParam(u => u.AspNetUsersId == userInaspNetTable.Id));
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> AgentInfo(string userName)
        {
            if (userName == null)
                return NotFound();

            var userInaspNetTable = await aspUserManager.FindByNameAsync(userName);
            if (userInaspNetTable == null)
                return NotFound();

            return Ok(agentManager.GetFirstOrDefaultByParam(a => a.AspNetUsersId == userInaspNetTable.Id));

        }


    }
}
