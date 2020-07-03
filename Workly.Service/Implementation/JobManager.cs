using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Workly.Domain;
using Workly.Repository;
using Workly.Service.Interfaces;

namespace Workly.Service.Implementation
{
    public class JobManager : IJobManager
    {
        private readonly IUnitOfWork unitOfWork;

        public JobManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(Job entity)
        {
            unitOfWork.JobRepository.Add(entity);
        }

        public void AddRange(IEnumerable<Job> entity)
        {
            unitOfWork.JobRepository.AddRange(entity);
        }

        public IEnumerable<Job> GetAll()
        {
            return unitOfWork.JobRepository.GetAll();
        }

        public Job GetFirstOrDefault(int recordId)
        {
            return unitOfWork.JobRepository.GetFirstOrDefault(recordId);
        }

        public Job GetFirstOrDefaultByParam(Expression<Func<Job, bool>> wherePredict)
        {
            return unitOfWork.JobRepository.GetFirstOrDefaultByParam(wherePredict);
        }

        public void Remove(Job entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveByWhereClause(Func<Job, bool> wherePredict)
        {
            throw new NotImplementedException();
        }
    }
}
