using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workly.Domain;
using Workly.Domain.Dtos;
using Workly.Service.Interfaces;

namespace Workly.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobManager jobManager;

        public JobsController(IJobManager jobManager, IMapper mapper)
        {
            this.jobManager = jobManager;
            _mapper = mapper;
        }

        public IActionResult GetJobs()
        {
            return Ok(jobManager.GetAll().Select(_mapper.Map<Job, JobDto>));
        }
    }
}
