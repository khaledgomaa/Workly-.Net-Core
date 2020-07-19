using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Workly.Repository.Interfaces;

namespace Workly.Repository.Implementation
{
    public class WorkerRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AgentDbContext dbContext;

        public WorkerRepository(AgentDbContext context)
        {
            dbContext = context;
        }


        #region Add Entity
        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entity)
        {
            dbContext.Set<TEntity>().AddRange(entity);
        }

        #endregion

        #region Get Entity
        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetFirstOrDefault(int recordId)
        {
            return dbContext.Set<TEntity>().Find(recordId);
        }

        public TEntity GetFirstOrDefaultByParam(Expression<Func<TEntity, bool>> wherePredict)
        {
            return dbContext.Set<TEntity>().Where(wherePredict).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAllWithInclude(Expression<Func<TEntity, object>> includePredict, Expression<Func<TEntity, bool>> wherePredict)
        {
            return dbContext.Set<TEntity>().Include(includePredict).Where(wherePredict);
        }
        #endregion

        #region Remove Entity
        public void Remove(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void RemoveByWhereClause(Func<TEntity, bool> wherePredict)
        {

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach(TEntity entity in entities)
            {
                dbContext.Entry(entity).State = EntityState.Deleted;
            }
            
        }

        #endregion


    }
}
