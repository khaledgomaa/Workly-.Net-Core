using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Workly.Api.Cloudinary;
using Workly.Domain;
using Workly.Domain.ViewModels;
using Workly.Service.Interfaces;

namespace Workly.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserAgentProfileController : ControllerBase
    {

        private readonly IUserManager userManager;
        private readonly IAgentManager agentManager;
        private readonly UserManager<ApplicationUser> aspUserManager;
        private readonly IAgentSkillManager agentSkillManager;
        private readonly IMapper mapper;
        private readonly ISkillManager skillManager;

        public UserAgentProfileController(IUserManager userManager
                                         , IAgentManager agentManager
                                         , UserManager<ApplicationUser> aspUserManager
                                         , IAgentSkillManager agentSkillManager
                                         , IMapper mapper
                                         , ISkillManager skillManager)
        {
            this.userManager = userManager;
            this.agentManager = agentManager;
            this.aspUserManager = aspUserManager;
            this.agentSkillManager = agentSkillManager;
            this.mapper = mapper;
            this.skillManager = skillManager;
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

        [HttpPut("{userName}")]
        public async Task<IActionResult> EditAgentProfile(string userName , EditAgent editedAgent)
        {
            if (userName == null || !ModelState.IsValid)
                return BadRequest();

            var userInaspNetTable = await aspUserManager.FindByNameAsync(userName);
            var agent = agentManager
                        .GetAllWithInclude(a => a.Job, a => a.AspNetUsersId == userInaspNetTable.Id).FirstOrDefault();
            if(agent.ImagePath != editedAgent.EditAgentInfo.ImagePath)
                editedAgent.EditAgentInfo.ImagePath = UploadToCloudinary.UploadImageToCloudinary(editedAgent.EditAgentInfo.ImagePath);

            mapper.Map(editedAgent.EditAgentInfo, agent);

            var agentEditedSkills = skillManager
                                    .GetAll()
                                    .Where(s => editedAgent.EditSkills.ToList().Select(a=>a.Name).Contains(s.Name))
                                    .Select(s=>s.Id)
                                    .ToList();

            var agentSkillsInDb = agentSkillManager
                                  .GetAll()
                                  .Where(s=>s.AgentId == agent.Id)
                                  .ToList();

          
            UpdateAgentSkills(agentEditedSkills, agentSkillsInDb);


            agentManager.Complete();

            return Ok();
        }

        private IEnumerable<string> getSkills(IEnumerable<AgentSkill> agentSkills)
        {
            foreach(AgentSkill agentSkill in agentSkills)
            {
                yield return agentSkill.Skill.Name;
            }
        }

        private void UpdateAgentSkills(List<int> newSkills , List<AgentSkill> agentSkillsInDb)
        {
            List<AgentSkill> newAgentAskills = new List<AgentSkill>();

            if(agentSkillsInDb.Count() <= newSkills.Count())
            {
                for (int i = 0; i < agentSkillsInDb.Count(); i++)
                {
                    agentSkillsInDb[i].SkillId = newSkills[0];
                    newSkills.Remove(newSkills[0]);
                }
                if (newSkills.Count() > 0)
                {
                    for (int i = 0; i < newSkills.Count(); i++)
                    {
                        newAgentAskills.Add(new AgentSkill { AgentId = agentSkillsInDb.First().AgentId, SkillId = newSkills[i] });
                    }

                    agentSkillManager.AddRange(newAgentAskills);
                }
            }
            else
            {
                for (int i = 0; i < newSkills.Count(); i++)
                {
                    if(!agentSkillsInDb.Select(s=>s.SkillId).Contains(newSkills[i]))
                        agentSkillsInDb[i].SkillId = newSkills[i];
                }
                newAgentAskills.AddRange(agentSkillsInDb.Where(s => !newSkills.Contains(s.SkillId)));
                agentSkillManager.RemoveRange(newAgentAskills);
            }
        }


    }
}
