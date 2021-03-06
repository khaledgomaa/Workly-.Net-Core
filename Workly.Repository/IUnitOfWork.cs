﻿using System;
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

        WorkerRepository<Agent> AgentRepository { get; }

        OrderRepository OrderRepository { get; }

        WorkerRepository<Job> JobRepository { get; }

        WorkerRepository<UserAddress> AddressRepository { get; }

        WorkerRepository<Skill> SkillRepository { get; }

        WorkerRepository<Notification> NotificationRepository { get; }

        WorkerRepository<AgentSkill> AgentSkillRepository { get; }
        void Complete();
    }
}
