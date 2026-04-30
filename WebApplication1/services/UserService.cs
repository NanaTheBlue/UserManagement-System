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





        public async Task<User?> GetUserFromSession(Guid id)
        {
            var user = await _userRepository.GetUserFromSession(id);

            if (user == null) { return null; }
            // Check if session is expired

            if (user.SessionExp == null || user.SessionExp < DateTime.UtcNow)
            {
                return null; // Session is expired or not set Should prob return a error instead
            }


            return user;
        }

        public async Task<UserDto?> RegisterUser(RegisterRequest RegisterRequest)
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




            var createdUser = await _userRepository.RegisterUser(user);

            if (createdUser == null) {


                return null;
            }


            return new UserDto
            {
                ID = createdUser.ID,
                Username = createdUser.Username,
                Email = createdUser.Email
            };


        }
    }


        
    }

