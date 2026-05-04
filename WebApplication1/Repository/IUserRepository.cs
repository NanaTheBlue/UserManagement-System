using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IUserRepository
    {
        
        Task<User?> RegisterUser(User user);
        Task<AuthenticatedUser?> GetUserFromSession(Guid id);

        Task<User?> GetUserFromEmail(string email);


    }



}
