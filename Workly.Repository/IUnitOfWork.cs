using System;
using System.Collections.Generic;
using System.Text;
using Workly.Domain;
using Workly.Repository.Implementation;

namespace Workly.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        WorkerRepository<User> UserRepository { get; }

        WorkerRepository<UserAddress> UserAddressRepository { get; }

        OrderRepository OrderRepository { get; }
        void Complete();
    }
}
