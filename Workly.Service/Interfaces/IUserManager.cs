using Workly.Domain;
using Workly.Repository.Interfaces;

namespace Workly.Service.Interfaces
{
    public interface IUserManager : IRepository<User>
    {
        //void Complete();
        void AddUser(User user,UserAddress userAddress);
        void Complete();
    }
}
