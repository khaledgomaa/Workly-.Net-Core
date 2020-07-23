using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Workly.Domain;
using Workly.Repository;
using Workly.Service.Interfaces;

namespace Workly.Service.Implementation
{
    public class NotificationManager : INotification
    {
        private readonly IUnitOfWork unitOfWork;
        public NotificationManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Notification> entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notification> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notification> GetAllWithInclude(Expression<Func<Notification, object>> includePredict, Expression<Func<Notification, bool>> wherePredict)
        {
            return unitOfWork.NotificationRepository.GetAllWithInclude(includePredict, wherePredict);
        }

        public Notification GetFirstOrDefault(int recordId)
        {
            throw new NotImplementedException();
        }

        public Notification GetFirstOrDefaultByParam(Expression<Func<Notification, bool>> wherePredict)
        {
            throw new NotImplementedException();
        }

        public void Remove(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveByWhereClause(Func<Notification, bool> wherePredict)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Notification> entities)
        {
            throw new NotImplementedException();
        }
    }
}
