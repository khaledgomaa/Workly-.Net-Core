using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Workly.Domain;
using Workly.Domain.ViewModels;
using Workly.Repository.Interfaces;
using Workly.Service.Interfaces;

namespace Workly.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        #region CTOR

        private readonly IUserManager dbContextUser;

        private readonly IRepository<UserAddress> dbContextUserAddress;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IAgentManager agentManager;

        private readonly IJobManager jobManager;

        private readonly IAddressManager addressManager;

        private readonly ISkillManager skillManager;

        private readonly IAgentSkillManager agentSkillManager;

        public static Cloudinary cloudinary;

        public const string CLOUD_NAME = "dcrllmnai";
        public const string API_KEY = "581332317551619";
        public const string API_SECRET = "Jm_ZH12L6l2RURuM37zqmjwGwBo";

        public AuthenticationController(IUserManager dbContextUser
                                        , IRepository<UserAddress> dbContextUserAddress
                                        , UserManager<ApplicationUser> userManager
                                        , IAgentManager agentManager
                                        , IJobManager jobManager
                                        , IAddressManager addressManager
                                        , ISkillManager skillManager
                                        , IAgentSkillManager agentSkillManager)
        {
            this.userManager = userManager;
            this.dbContextUser = dbContextUser;
            this.dbContextUserAddress = dbContextUserAddress;
            this.agentManager = agentManager;
            this.jobManager = jobManager;
            this.addressManager = addressManager;
            this.skillManager = skillManager;
            this.agentSkillManager = agentSkillManager;
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterationModelForUsers registerationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (await CheckIfUserExist(registerationModel.UserSecurity))
                return BadRequest();

            registerationModel.UserInfo.UserAddress = registerationModel.Address;

            addressManager.Add(registerationModel.Address);
            dbContextUser.Add(registerationModel.UserInfo);

            string id = await AddUserToAspNetUsers(registerationModel.UserSecurity, registerationModel.UserInfo , "user");

            if (id != null)
            {
                string imagePath = UploadImageToCloudinary(registerationModel.UserInfo.ImagePath);

                if (imagePath != null)
                {
                    registerationModel.UserInfo.ImagePath = imagePath;
                    registerationModel.UserInfo.AspNetUsersId = id;
                    dbContextUser.Complete();
                    return Ok();
                }
        
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAgent(RegisterationModelForAgents registerationModelForAgents)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (await CheckIfUserExist(registerationModelForAgents.UserSecurity))
                return BadRequest();

            var JobInDb = jobManager.
                              GetFirstOrDefaultByParam(j => j.Name == registerationModelForAgents.JobInfo.Name);

            if (JobInDb == null)
                return BadRequest();

            //Get Skills from Database
            IEnumerable<Skill> skillsInDb = skillManager.GetAll().Where(s => registerationModelForAgents.Skills.Contains(s.Name));

            if (skillsInDb == null)
                return BadRequest();

            agentManager.Add(registerationModelForAgents.AgentInfo);

            registerationModelForAgents.AgentInfo.Job = JobInDb;

            string id = await AddUserToAspNetUsers(registerationModelForAgents.UserSecurity, registerationModelForAgents.AgentInfo, "worker");

            if (id != null)
            {
                registerationModelForAgents.AgentInfo.AspNetUsersId = id;

                AddAgentSkills(skillsInDb, registerationModelForAgents.AgentInfo);

                string imagePath = UploadImageToCloudinary(registerationModelForAgents.AgentInfo.ImagePath);

                if(imagePath != null)
                {
                    registerationModelForAgents.AgentInfo.ImagePath = imagePath;
                    dbContextUser.Complete();
                    return Ok();
                }  
            }

        return BadRequest();
    }

    private async Task<string> AddUserToAspNetUsers(MyUserAspNet userSecurity, User userInfo, string role)
        {

            ApplicationUser user = new ApplicationUser { UserName = userSecurity.UserName , User = userInfo };
            var check = await userManager.CreateAsync(user, userSecurity.Password);
            if (check.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
                return user.Id;
            }
            return null;
        }

        private async Task<string> AddUserToAspNetUsers(MyUserAspNet userSecurity, Agent agentInfo, string role)
        {

            ApplicationUser user = new ApplicationUser { UserName = userSecurity.UserName, Agent = agentInfo };

            var check = await userManager.CreateAsync(user, userSecurity.Password);
            if (check.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
                return user.Id;
            }
            return null;
        }

        private void AddAgentSkills(IEnumerable<Skill> skills , Agent agent)
        {
            List<AgentSkill> agentSkills= new List<AgentSkill>();

            foreach(Skill skill in skills)
            {
                agentSkills.Add(new AgentSkill { Skill = skill, Agent = agent });
            }

            agentSkillManager.AddRange(agentSkills);
        }

        private async Task<bool> CheckIfUserExist(MyUserAspNet userSecurity)
        {
            ApplicationUser user = new ApplicationUser { UserName = userSecurity.UserName};

            return (await userManager.FindByNameAsync(userSecurity.UserName) == null) ? false : true;
        }

        private string UploadImageToCloudinary(string Image)
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);
            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(Image)
                };
                //new image path on cloudinary
                var urlOnCloudinary = cloudinary.UploadAsync(uploadParams).Result.Uri;
                return urlOnCloudinary.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        //onion architecture
        //Domain Layer , data access 
        //Repository<job> , DbContext
        //Service Layer IUserService business login
        //ui , presentaion layer
        //Soc , lossly coupled
    }
}
