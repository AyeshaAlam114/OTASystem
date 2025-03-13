using System.Threading.Tasks;
using OTASystem.Data.Models;
using OTASystem.Repositories;
using OTASystem.Services;

namespace OTASystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null || user.PasswordHash != password)
                return null;

            return user;
        }
    }
}
