using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> RegisterUser(RegisterRequest RegisterRequest)
        {

            if (string.IsNullOrEmpty(RegisterRequest.Username) || string.IsNullOrEmpty(RegisterRequest.Email) || string.IsNullOrEmpty(RegisterRequest.Password))
            {
                throw new ArgumentException("Username, Email and Password are required.");
            }



            if (RegisterRequest.Password.Length < 10)
            {
                throw new Exception("Password Must Be Atleast 10 Characters In Length");
            }

            var salt = BC.GenerateSalt();
            var hashedPW = BC.HashPassword(RegisterRequest.Password, salt );


             var user = new User
            {
                Username = RegisterRequest.Username,
                Email = RegisterRequest.Email,
                PasswordHash = hashedPW,
            };




            return await _userRepository.RegisterUser(user);
        }
    }


        
    }

