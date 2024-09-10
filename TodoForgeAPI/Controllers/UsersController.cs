using Contracts.User;
using Database.Repositories.UserRepo;
using Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoForgeAPI.Services;

namespace TodoForgeAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
        private readonly PasswordHasher<UserDto> _passwordHasher;

        public UsersController(IUserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _passwordHasher = new PasswordHasher<UserDto>();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {

            var userDto = new UserDto(
                request.Username,
                request.Email,
                request.Password,
                true,
                DateTime.UtcNow,
                DateTime.UtcNow
             );

            var passwordHash = _passwordHasher.HashPassword(userDto, userDto.Password);

            userDto.Password = passwordHash;

            await _userRepository.Insert(userDto);

            return Ok("User created successfully.");
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

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, login.Password);

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Invalid credentials");

            var jwtToken = _jwtService.GenerateToken(user.Username);

            return Ok(new { Token = jwtToken });
        }
    }
}
