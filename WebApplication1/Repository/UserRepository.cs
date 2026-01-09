using Microsoft.Data.SqlClient;
using WebApplication1.Models;


namespace WebApplication1.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Default");
        }
        public async Task<User?> GetByIdAsync(Guid id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            using var cmd = new SqlCommand("SELECT Id, Username,Email FROM Users WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();

            
            if (!reader.Read()) return null;

            return new User
            {
                ID = reader.GetGuid(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2),
            };
        }

        public async Task<User?> CreateUser(User user)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            return null;
        }





    }
}
