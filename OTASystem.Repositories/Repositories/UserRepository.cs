using Microsoft.EntityFrameworkCore;
using OTASystem.Data.Models;
using OTASystem.Data;
using System.Threading.Tasks;

namespace OTASystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByCredentials(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);
        }
    }
}
