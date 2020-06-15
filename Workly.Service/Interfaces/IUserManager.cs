using Workly.Domain;

namespace Workly.Service.Interfaces
{
    public interface IUserManager
    {
        void AddUser(User user);

        void Complete();
    }
}
