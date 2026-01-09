namespace WebApplication1.Models
{
    public class User
    {
        public required Guid ID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
