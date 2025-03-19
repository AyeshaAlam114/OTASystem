

namespace OTASystem.Services
{
    public interface IUserService
    {
        Task<string> Authenticate(string username, string password);
    }
}
