﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Workly.Domain;
using Workly.Repository;
using Workly.Service.Interfaces;

namespace Workly.Service.Implementation
{
    public class AgentManager : IAgentManager
    {
        private readonly IUnitOfWork unitOfWork;

        public AgentManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Agent entity)
        {
            unitOfWork.AgentRepository.Add(entity);
        }

        public void AddRange(IEnumerable<Agent> entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agent> GetAll()
        {
            throw new NotImplementedException();
        }

        public Agent GetFirstOrDefault(int recordId)
        {
            return unitOfWork.AgentRepository.GetFirstOrDefault(recordId);
        }

        public Agent GetFirstOrDefaultByParam(Expression<Func<Agent, bool>> wherePredict)
        {

            return unitOfWork.AgentRepository.GetFirstOrDefaultByParam(wherePredict);
        }

        public IEnumerable<Agent> GetAllWithInclude(Expression<Func<Agent, object>> includePredict, Expression<Func<Agent, bool>> wherePredict)
        {
            return unitOfWork.AgentRepository.GetAllWithInclude(includePredict, wherePredict);
        }

        public void Remove(Agent entity)
        {
            unitOfWork.AgentRepository.Remove(entity);
        }

        public void RemoveByWhereClause(Func<Agent, bool> wherePredict)
        {
            throw new NotImplementedException();
        }

        public void Complete()
        {
            unitOfWork.Complete();
        }

        public void RemoveRange(IEnumerable<Agent> entities)
        {
            throw new NotImplementedException();
        }
    }
}
