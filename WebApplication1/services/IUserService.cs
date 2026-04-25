using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
       
        Task<User?> RegisterUser(RegisterRequest registerRequest);
    }
}
