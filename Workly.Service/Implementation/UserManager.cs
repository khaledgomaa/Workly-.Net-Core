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
        private IUnitOfWork dbContext;

        public UserManager(IUnitOfWork dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User entity)
        {
            //dbContext.UserRepository.Add(entity);
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
            throw new NotImplementedException();
        }

        public User GetFirstOrDefaultByParam(Expression<Func<User, bool>> wherePredict)
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveByWhereClause(Func<User, bool> wherePredict)
        {
            throw new NotImplementedException();
        }
    }
}
