using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Workly.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
            #region Get entities 
            IEnumerable<TEntity> GetAll();
            TEntity GetFirstOrDefault(int recordId);
            TEntity GetFirstOrDefaultByParam(Expression<Func<TEntity, bool>> wherePredict);
            IEnumerable<TEntity> GetAllWithInclude(Expression<Func<TEntity, object>> includePredict , Expression<Func<TEntity, bool>> wherePredict);
            
            #endregion

            #region Add entities
            void Add(TEntity entity);
            void AddRange(IEnumerable<TEntity> entity);
            

            #endregion

            #region Remove entities

            void Remove(TEntity entity);
            void RemoveByWhereClause(Func<TEntity, bool> wherePredict);
            void RemoveRange(IEnumerable<TEntity> entities);

            #endregion

    }
}
