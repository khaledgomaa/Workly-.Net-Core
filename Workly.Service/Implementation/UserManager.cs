using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Workly.Domain;
using Workly.Repository;
using Workly.Repository.Interfaces;
using Workly.Service.Interfaces;

namespace Workly.Service.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork dbContext;

        public UserManager(IUnitOfWork dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User entity)
        {
            dbContext.UserRepository.Add(entity);
        }

        //Add into user table and address
        public void AddUser(User user, UserAddress userAddress)
        {
            dbContext.UserRepository.Add(user);
            dbContext.UserAddressRepository.Add(userAddress);
        }

        public void AddRange(IEnumerable<User> entity)
        {
            throw new NotImplementedException();
        }

        

        public void Complete()
        {
            dbContext.Complete();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetFirstOrDefault(int recordId)
        {
            return dbContext.UserRepository.GetFirstOrDefault(recordId);
        }

        public User GetFirstOrDefaultByParam(Expression<Func<User, bool>> wherePredict)
        {
            return dbContext.UserRepository.GetFirstOrDefaultByParam(wherePredict);
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveByWhereClause(Func<User, bool> wherePredict)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllWithInclude(Expression<Func<User, object>> includePredict, Expression<Func<User, bool>> wherePredict)
        {
            return dbContext.UserRepository.GetAllWithInclude(includePredict, wherePredict);
        }

        public void RemoveRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }
    }
}
