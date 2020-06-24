using System;
using System.Collections.Generic;
using System.Text;
using Workly.Domain;
using Workly.Repository.Implementation;
using Workly.Repository.Interfaces;

namespace Workly.Repository
{
    public class GenericUnitOfWork : IUnitOfWork
    {
        private readonly AgentDbContext dbContext;
        private WorkerRepository<User> userRepository;
        private WorkerRepository<UserAddress> userAddressRepository;
        private OrderRepository orderRepository;

        public GenericUnitOfWork(AgentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public WorkerRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new WorkerRepository<User>(dbContext);
                return this.userRepository;
            }
        }

        public WorkerRepository<UserAddress> UserAddressRepository
        {
            get
            {
                if (this.userAddressRepository == null)
                    this.userAddressRepository = new WorkerRepository<UserAddress>(dbContext);
                return this.userAddressRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                    this.orderRepository = new OrderRepository(dbContext);
                return this.orderRepository;
            }
        }

        public void Complete()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
