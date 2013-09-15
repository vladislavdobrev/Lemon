using MelonStore.Models;
using System.Linq;

namespace MelonStore.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User LoginUser(User user);

        void LogoutUser(string sessionkey);

        string GenerateSessionKey(int id);
    }
}