using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workly.Service.Interfaces;

namespace Workly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager orderDbContext;

        public OrderController(IOrderManager orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        public IActionResult RequestOrder()
        {
            return Ok();
        }
    }
}
