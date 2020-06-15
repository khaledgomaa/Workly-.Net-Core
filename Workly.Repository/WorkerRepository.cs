using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Workly.Repository
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
        #endregion

        #region Remove Entity
        public void Remove(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void RemoveByWhereClause(Func<TEntity, bool> wherePredict)
        {

        }

        #endregion


        public void Complete()
        {
            dbContext.SaveChanges();
        }

    }
}
