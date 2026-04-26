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





        public async Task<UserDto?> GetSession(Guid id)
        {
            return await _userRepository.GetSession(id);

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

                // need to handle dis better
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

