using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Workly.Domain;
using Workly.Repository;
using Workly.Service.Interfaces;

namespace Workly.Service.Implementation
{
    public class AgentSkillManager : IAgentSkillManager
    {
        private readonly IUnitOfWork unitOfWork;

        public AgentSkillManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(AgentSkill entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<AgentSkill> entity)
        {
            unitOfWork.AgentSkillRepository.AddRange(entity);
        }

        public IEnumerable<AgentSkill> GetAll()
        {
            return unitOfWork.AgentSkillRepository.GetAll();
        }

        public AgentSkill GetFirstOrDefault(int recordId)
        {
            throw new NotImplementedException();
        }

        public AgentSkill GetFirstOrDefaultByParam(Expression<Func<AgentSkill, bool>> wherePredict)
        {
            return unitOfWork.AgentSkillRepository.GetFirstOrDefaultByParam(wherePredict);
        }

        public IEnumerable<AgentSkill> GetAllWithInclude(Expression<Func<AgentSkill, object>> includePredict, Expression<Func<AgentSkill, bool>> wherePredict)
        {
            return unitOfWork.AgentSkillRepository.GetAllWithInclude(includePredict, wherePredict);
        }

        public void Remove(AgentSkill entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveByWhereClause(Func<AgentSkill, bool> wherePredict)
        {
            throw new NotImplementedException();
        }

        public void Complete()
        {
            unitOfWork.Complete();
        }

        public void RemoveRange(IEnumerable<AgentSkill> entities)
        {
            unitOfWork.AgentSkillRepository.RemoveRange(entities);
        }
    }
}
