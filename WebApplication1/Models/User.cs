namespace WebApplication1.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
    }
}
