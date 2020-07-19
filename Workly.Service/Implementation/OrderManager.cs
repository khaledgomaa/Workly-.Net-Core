using Workly.Domain;
using Workly.Service.Interfaces;
using Workly.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Workly.Repository;

namespace Workly.Service.Implementation
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork dbContext;

        public OrderManager(IUnitOfWork dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Order entity)
        {
            dbContext.OrderRepository.Add(entity);
        }

        public void AddRange(IEnumerable<Order> entity)
        {
            throw new NotImplementedException();
        }

        public void Complete() => dbContext.Complete();

        public IEnumerable<Order> GetAll()
        {
            return dbContext.OrderRepository.GetAll();
        }

        public Order GetFirstOrDefault(int recordId)
        {
            throw new NotImplementedException();
        }

        public Order GetFirstOrDefaultByParam(Expression<Func<Order, bool>> wherePredict)
        {
            return dbContext.OrderRepository.GetFirstOrDefaultByParam(wherePredict);
        }

        public IEnumerable<Order> GetAllWithInclude(Expression<Func<Order, object>> includePredict, Expression<Func<Order, bool>> wherePredict)
        {
            return dbContext.OrderRepository.GetAllWithInclude(includePredict, wherePredict);
        }

        public void Remove(Order entity)
        {
            dbContext.OrderRepository.Remove(entity);
        }

        public void RemoveByWhereClause(Func<Order, bool> wherePredict)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Order> entities)
        {
            dbContext.OrderRepository.RemoveRange(entities);
        }
    }
}
