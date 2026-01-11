using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        Task<User?> GetUser(Guid id);
        Task<User?> CreateUser(User user);
    }
}
