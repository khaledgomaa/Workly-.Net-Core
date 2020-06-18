using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Workly.Domain;
using Workly.Repository.Interfaces;

namespace Workly.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AgentDbContext dbContext;

        public OrderRepository(AgentDbContext context)
        {
            dbContext = context;
        }

        public void Add(Order order)
        {
            dbContext.Set<Order>().FromSqlRaw("InsertIntoOrder",order);
        }

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
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Order> entity)
        {
            throw new NotImplementedException();
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
