using System;
using System.Collections.Generic;
using System.Text;
using Workly.Domain;
using Workly.Repository.Interfaces;

namespace Workly.Service.Interfaces
{
    public interface IAgentSkillManager : IRepository<AgentSkill>
    {
        void Complete();
    }
}
