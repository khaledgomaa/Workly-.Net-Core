using Microsoft.Data.SqlClient;
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
            SqlParameter[] param = new SqlParameter[] {
            new SqlParameter("@user_id",order.UserId),
            new SqlParameter("@agent_id", order.AgentId),
            new SqlParameter("@loc", order.Location),
            new SqlParameter("@mydate", order.Date),
            new SqlParameter("@rate", order.AgentRate)
        };
            //dbContext.Orders.FromSqlRaw("exec InsertIntoOrder @user_id,@agent_id,@loc,@mydate,@rate", param);
            dbContext.Database.ExecuteSqlCommand("InsertIntoOrder @user_id,@agent_id,@loc,@mydate,@rate", param);
        }

        public IEnumerable<Order> GetAll()
        {
            return dbContext.Orders.ToList();
        }

        public Order GetFirstOrDefault(int recordId)
        {
            throw new NotImplementedException();
        }

        public Order GetFirstOrDefaultByParam(Expression<Func<Order, bool>> wherePredict)
        {
            return dbContext.Orders.FirstOrDefault(wherePredict);
        }

        public void AddRange(IEnumerable<Order> entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Order entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void RemoveByWhereClause(Func<Order, bool> wherePredict)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Order> GetAllWithInclude(Expression<Func<Order, object>> includePredict, Expression<Func<Order, bool>> wherePredict)
        {
            return dbContext.Orders.Include(includePredict).Where(wherePredict);
        }

        public void RemoveRange(IEnumerable<Order> entities)
        {
            foreach (Order entity in entities)
            {
                dbContext.Entry(entity).State = EntityState.Deleted;
            }
        }
    }
}
