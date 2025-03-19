using OTASystem.Data.Models;
using System.Threading.Tasks;

namespace OTASystem.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByCredentials(string username, string password);
    }
}
