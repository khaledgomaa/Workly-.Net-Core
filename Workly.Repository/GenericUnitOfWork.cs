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
        private  WorkerRepository<User> userRepository;
        private  WorkerRepository<UserAddress> userAddressRepository;
        private  OrderRepository orderRepository;
        private  WorkerRepository<Agent> agentRepository;
        private WorkerRepository<Job> jobRepository;
        private WorkerRepository<UserAddress> addressRepository;

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

        public WorkerRepository<Agent> AgentRepository
        {
            get
            {
                if (this.agentRepository == null)
                    this.agentRepository = new WorkerRepository<Agent>(dbContext);
                return this.agentRepository;
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

        public WorkerRepository<Job> JobRepository
        {
            get
            {
                if (this.jobRepository == null)
                    this.jobRepository = new WorkerRepository<Job>(dbContext);
                return this.jobRepository;
            }
        }

        public WorkerRepository<UserAddress> AddressRepository
        {
            get
            {
                if (this.addressRepository == null)
                    this.addressRepository = new WorkerRepository<UserAddress>(dbContext);
                return this.addressRepository;
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
