using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Workly.Domain;
using Workly.Repository;
using Workly.Service.Interfaces;

namespace Workly.Service.Implementation
{
    public class SkillManager : ISkillManager
    {
        private readonly IUnitOfWork unitOfWork;
        public SkillManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(Skill entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Skill> entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skill> GetAll()
        {
            return unitOfWork.SkillRepository.GetAll();
        }

        public Skill GetFirstOrDefault(int recordId)
        {
            throw new NotImplementedException();
        }

        public Skill GetFirstOrDefaultByParam(Expression<Func<Skill, bool>> wherePredict)
        {
            return unitOfWork.SkillRepository.GetFirstOrDefaultByParam(wherePredict);
        }

        public void Remove(Skill entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveByWhereClause(Func<Skill, bool> wherePredict)
        {
            throw new NotImplementedException();
        }
    }
}
