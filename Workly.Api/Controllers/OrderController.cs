using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Workly.Domain;
using Workly.Domain.ViewModels;
using Workly.Repository;
using Workly.Service.Interfaces;

namespace Workly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager orderDbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserManager iUserManager;
        private readonly IAgentManager agentManager;

        public OrderController(  IOrderManager orderDbContext
                               , UserManager<ApplicationUser> userManager
                               , IUserManager iUserManager
                               , IAgentManager agentManager)
        {
            this.orderDbContext = orderDbContext;
            this.userManager = userManager;
            this.agentManager = agentManager;
            this.iUserManager = iUserManager;
        }

        [HttpPost]
        public async Task<IActionResult> RequestOrder(OrderRequest orderRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var agentInAspNetUsers = await userManager.FindByNameAsync(orderRequest.AgentName);

            var userInAspNetUsers = await userManager.FindByNameAsync(orderRequest.UserName);

            if (agentInAspNetUsers == null || userInAspNetUsers == null)
                return NotFound();

            User user = iUserManager.GetFirstOrDefaultByParam(u => u.AspNetUsersId == userInAspNetUsers.Id);
            Agent agent = agentManager.GetFirstOrDefaultByParam(a => a.AspNetUsersId == agentInAspNetUsers.Id);

            bool checkIfUserHasAlreadyRequestAgent = CheckUserRequestAgent(user.Id , agent.Id);

            if(!checkIfUserHasAlreadyRequestAgent)
            {
                Order order = new Order
                {
                    AgentId = agent.Id,
                    UserId = user.Id,
                    Location = orderRequest.Location,
                    AgentRate = agent.Rate,
                    Date = DateTime.UtcNow
                };

                orderDbContext.Add(order);

                orderDbContext.Complete();

                return Ok();
            }

            return BadRequest();
            
        }

        private bool CheckUserRequestAgent(int userId , int agentId)
        {

            var checkIfRequestExist = orderDbContext
                                        .GetFirstOrDefaultByParam
                                        (o => o.AgentId == agentId && o.UserId == userId && o.AgentAction == 0);

            if (checkIfRequestExist == null)
                return false;

            return true;
        }
    }
}
