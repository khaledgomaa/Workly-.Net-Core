using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workly.Domain;
using Workly.Domain.Dtos;

namespace Workly.Api
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Skill, SkillsDto>();
            CreateMap<SkillsDto, Skill>();
            CreateMap<Job, JobDto>();
        }
    }
}
