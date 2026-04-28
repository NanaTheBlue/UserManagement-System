namespace WebApplication1.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public  string ?PasswordHash { get; set; }
    }

    public class RegisterRequest
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class UserDto
    {
        public Guid ID { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
    }
}
