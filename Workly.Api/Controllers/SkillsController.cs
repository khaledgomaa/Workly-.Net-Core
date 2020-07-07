using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workly.Domain;
using Workly.Domain.Dtos;
using Workly.Service.Interfaces;

namespace Workly.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillManager skillManager;
        private readonly IMapper _mapper;

        public SkillsController(ISkillManager skillManager , IMapper mapper)
        {
            this.skillManager = skillManager;
            _mapper = mapper;
        }

        public IActionResult GetSkills()
        {
            return Ok(skillManager.GetAll().Select(_mapper.Map<Skill,SkillsDto>));
        }
    }
}
