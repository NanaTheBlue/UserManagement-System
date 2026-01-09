using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid user ID.");
            }

            try {
                var user = await _userRepository.GetById(id);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            } catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving the user.");
            }
           
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User payload cannot be null.");
            }
                
            try
            {
                var createdUser = await _userRepository.CreateUser(user);
                if (createdUser == null)
                {
                    return BadRequest("User could not be created.");
                }
                return Ok(createdUser);
            }
            catch (Exception)
            {
              
                return StatusCode(500, "An error occurred while creating the user.");
            }
        }

    }
}
