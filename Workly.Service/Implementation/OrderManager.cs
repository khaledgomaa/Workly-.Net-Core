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
            throw new NotImplementedException();
        }

        public Order GetFirstOrDefault(int recordId)
        {
            throw new NotImplementedException();
        }

        public Order GetFirstOrDefaultByParam(Expression<Func<Order, bool>> wherePredict)
        {
            return dbContext.OrderRepository.GetFirstOrDefaultByParam(wherePredict);
        }

        public void Remove(Order entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveByWhereClause(Func<Order, bool> wherePredict)
        {
            throw new NotImplementedException();
        }
    }
}
