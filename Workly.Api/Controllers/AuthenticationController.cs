using System;
using System.Threading.Tasks;
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

        public AuthenticationController(IUserManager dbContextUser
                                        , IRepository<UserAddress> dbContextUserAddress
                                        , UserManager<ApplicationUser> userManager
                                        , IAgentManager agentManager
                                        , IJobManager jobManager
                                        , IAddressManager addressManager)
        {
            this.userManager = userManager;
            this.dbContextUser = dbContextUser;
            this.dbContextUserAddress = dbContextUserAddress;
            this.agentManager = agentManager;
            this.jobManager = jobManager;
            this.addressManager = addressManager;
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterationModelForUsers registerationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            registerationModel.UserInfo.UserAddress = registerationModel.Address;

            addressManager.Add(registerationModel.Address);
            dbContextUser.Add(registerationModel.UserInfo);

            string id = await AddUserToAspNetUsers(registerationModel.UserSecurity, registerationModel.UserInfo , "user");

            if (id != null)
            {
                registerationModel.UserInfo.AspNetUsersId = id;
                dbContextUser.Complete();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAgent(RegisterationModelForAgents registerationModelForAgents)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var JobInDb = jobManager.
                              GetFirstOrDefaultByParam(j => j.Name == registerationModelForAgents.JobInfo.Name);

            if (JobInDb == null)
                return BadRequest();

            agentManager.Add(registerationModelForAgents.AgentInfo);

            registerationModelForAgents.AgentInfo.Job = JobInDb;

            string id = await AddUserToAspNetUsers(registerationModelForAgents.UserSecurity, registerationModelForAgents.AgentInfo, "worker");

            if (id != null)
            {
                registerationModelForAgents.AgentInfo.AspNetUsersId = id;

                dbContextUser.Complete();

                return Ok();
            }

        return BadRequest();
    }

    private async Task<string> AddUserToAspNetUsers(MyUserAspNet userSecurity, User userInfo, string role)
        {

            ApplicationUser user = new ApplicationUser { UserName = userSecurity.UserName , User = userInfo };

            bool checkifUserExist = (await userManager.FindByNameAsync(userSecurity.UserName) == null) ? false : true;

            if (!checkifUserExist)
            {
                await userManager.CreateAsync(user, userSecurity.Password);
                await userManager.AddToRoleAsync(user, role);
            }

            return user.Id;
        }

        private async Task<string> AddUserToAspNetUsers(MyUserAspNet userSecurity, Agent agentInfo, string role)
        {

            ApplicationUser user = new ApplicationUser { UserName = userSecurity.UserName, Agent = agentInfo };

            bool checkifUserExist = (await userManager.FindByNameAsync(userSecurity.UserName) == null) ? false : true;

            if (!checkifUserExist)
            {
                await userManager.CreateAsync(user, userSecurity.Password);
                await userManager.AddToRoleAsync(user, role);
            }

            return user.Id;
        }


        //onion architecture
        //Domain Layer , data access 
        //Repository<job> , DbContext
        //Service Layer IUserService business login
        //ui , presentaion layer
        //Soc , lossly coupled
    }
}
