using Contracts.User;
using Database.Repositories.UserRepo;
using Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TodoForgeAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var user = new CreateUserDto(
                request.Username,
                request.Email,
                request.Password
             );

            await _userRepository.Insert(user);

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = await _userRepository.GetByEmail(
                login.Email
            );

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
