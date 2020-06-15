using Workly.Domain;
using Workly.Repository;
using Workly.Service.Interfaces;

namespace Workly.Service.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IRepository<User> dbContext;

        public UserManager(IRepository<User> dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            dbContext.Add(user);
        }

        public void Complete()
        {
            dbContext.Complete();
        }
    }
}
