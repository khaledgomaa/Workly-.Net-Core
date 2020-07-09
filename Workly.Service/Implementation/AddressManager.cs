using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Workly.Domain;
using Workly.Repository;
using Workly.Service.Interfaces;

namespace Workly.Service.Implementation
{
    public class AddressManager : IAddressManager
    {
        private readonly IUnitOfWork unitOfWork;

        public AddressManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(UserAddress entity)
        {
            unitOfWork.AddressRepository.Add(entity);
        }

        public void AddRange(IEnumerable<UserAddress> entity)
        {
            throw new NotImplementedException();
        }

        public void Complete()
        {
            unitOfWork.Complete();
        }

        public IEnumerable<UserAddress> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserAddress GetFirstOrDefault(int recordId)
        {
            throw new NotImplementedException();
        }

        public UserAddress GetFirstOrDefaultByParam(Expression<Func<UserAddress, bool>> wherePredict)
        {
            throw new NotImplementedException();
        }

        public UserAddress GetFirstOrDefautWithInclude(Expression<Func<UserAddress, bool>> includePredict, Expression<Func<UserAddress, bool>> wherePredict)
        {
            throw new NotImplementedException();
        }

        public void Remove(UserAddress entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveByWhereClause(Func<UserAddress, bool> wherePredict)
        {
            throw new NotImplementedException();
        }
    }
}
