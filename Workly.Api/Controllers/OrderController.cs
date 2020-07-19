using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager orderDbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserManager iUserManager;
        private readonly IAgentManager agentManager;

        public OrderController(IOrderManager orderDbContext
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

            UserAgent userAgent = await GetAgentAndUser(orderRequest.UserName, orderRequest.AgentName);

            Order order = new Order
            {
                AgentId = userAgent.Agent.Id,
                UserId = userAgent.User.Id,
                Location = userAgent.User.UserAddress.Address,
                AgentRate = userAgent.Agent.Rate,
                Date = DateTime.UtcNow
            };

            orderDbContext.Add(order);

            orderDbContext.Complete();

            return Ok();

        }

        [HttpGet("{userName}/{agentName}")]
        public async Task<IActionResult> CheckUserRequestAgent(string userName, string agentName)
        {
            UserAgent userAgent = await GetAgentAndUser(userName, agentName);

            var checkIfRequestExist = orderDbContext
                                        .GetFirstOrDefaultByParam
                                        (o => o.AgentId == userAgent.Agent.Id && o.UserId == userAgent.User.Id && o.AgentAction == 0);

            if (checkIfRequestExist == null)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{userName}/{agentName}")]

        public async Task<IActionResult> DeleteOrder(string userName, string agentName)
        {
            UserAgent userAgent = await GetAgentAndUser(userName, agentName);

            orderDbContext.RemoveRange(orderDbContext
                          .GetAll()
                          .Where(o => o.AgentId == userAgent.Agent.Id && o.UserId == userAgent.User.Id && o.AgentAction == 0));

            orderDbContext.Complete();

            return Ok();
        }

        private async Task<UserAgent> GetAgentAndUser(string userName, string agentName)
        {
            var agentInAspNetUsers = await userManager.FindByNameAsync(agentName);

            var userInAspNetUsers = await userManager.FindByNameAsync(userName);

            if (agentInAspNetUsers == null || userInAspNetUsers == null)
                return null;

            IEnumerable<User> user = iUserManager.GetAllWithInclude(u=>u.UserAddress , u => u.AspNetUsersId == userInAspNetUsers.Id);
            Agent agent = agentManager.GetFirstOrDefaultByParam(a => a.AspNetUsersId == agentInAspNetUsers.Id);

            return new UserAgent {User = user.FirstOrDefault() , Agent = agent};
        }
    }
}
