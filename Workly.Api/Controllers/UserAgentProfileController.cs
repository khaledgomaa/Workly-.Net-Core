using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Workly.Domain;
using Workly.Domain.ViewModels;
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
        private readonly IAgentSkillManager agentSkillManager;

        public UserAgentProfileController(IUserManager userManager
                                         , IAgentManager agentManager
                                         , UserManager<ApplicationUser> aspUserManager
                                         , IAgentSkillManager agentSkillManager)
        {
            this.userManager = userManager;
            this.agentManager = agentManager;
            this.aspUserManager = aspUserManager;
            this.agentSkillManager = agentSkillManager;
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

            var agent = agentManager.GetAllWithInclude(a => a.Job, a => a.AspNetUsersId == userInaspNetTable.Id).FirstOrDefault();

            IEnumerable<AgentSkill> agnetSkills = agentSkillManager.GetAllWithInclude(s => s.Skill, s => s.AgentId == agent.Id).ToList();

            IEnumerable<string> mySkills = getSkills(agnetSkills);

            AgentProfile agentProfile = new AgentProfile
            {
                Email = agent.Email,
                Experience = agent.Experience,
                ImagePath = agent.ImagePath,
                JobName = agent.Job.Name,
                Location = agent.Location,
                PhoneNumber = agent.PhoneNumber,
                Rate = agent.Rate,
                UserName = userInaspNetTable.UserName,
                Skills = mySkills
            };

            return Ok(agentProfile);

        }

        private IEnumerable<string> getSkills(IEnumerable<AgentSkill> agentSkills)
        {
            foreach(AgentSkill agentSkill in agentSkills)
            {
                yield return agentSkill.Skill.Name;
            }
        }


    }
}
