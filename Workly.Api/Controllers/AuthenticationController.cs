using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Workly.Domain;
using Workly.Domain.ViewModels;
using Workly.Repository;
using Workly.Repository.Models;
using Workly.Service.Interfaces;

namespace Workly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        #region CTOR

        private readonly IUserManager dbContextUser;

        private readonly IRepository<UserAddress> dbContextUserAddress;

        private readonly UserManager<ApplicationUser> userManager;


        public AuthenticationController(IUserManager dbContextUser
                                        , IRepository<UserAddress> dbContextUserAddress
                                        ,UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.dbContextUser = dbContextUser;
            this.dbContextUserAddress = dbContextUserAddress;
        }

        #endregion


        public async Task<IActionResult> RegisterUser(RegisterationModel registerationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            registerationModel.UserInfo.UserAddress = registerationModel.Address;

            dbContextUser.AddUser(registerationModel.UserInfo);
            dbContextUserAddress.Add(registerationModel.Address);

            if (await AddUserToAspNetUsers(registerationModel.UserSecurity, registerationModel.UserInfo))
            {
                dbContextUser.Complete();
                return Ok();
            }
            return BadRequest();
        }

        private async Task<bool> AddUserToAspNetUsers(MyUserAspNet userSecurity , User userInfo)
        {

            ApplicationUser user = new ApplicationUser { UserName = userSecurity.UserName, User = userInfo };

            bool checkifUserExist = (await userManager.FindByNameAsync(userSecurity.UserName) == null) ? false : true;

            if (!checkifUserExist)
                await userManager.CreateAsync(user, userSecurity.Password);

            return !checkifUserExist;
        }
        //onion architecture
        //Domain Layer , data access 
        //Repository<job> , DbContext
        //Service Layer IUserService business login
        //ui , presentaion layer
        //Soc , lossly coupled
    }
}
