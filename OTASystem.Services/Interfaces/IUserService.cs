using OTASystem.Data.Models;
using System.Threading.Tasks;

namespace OTASystem.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}
