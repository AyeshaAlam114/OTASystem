using System.Text.Json;
using OTASystem.Repositories;

namespace OTASystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetUserByCredentials(username, password);
            if (user == null) return null;

            return JsonSerializer.Serialize(new
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            });
        }
    }
}
