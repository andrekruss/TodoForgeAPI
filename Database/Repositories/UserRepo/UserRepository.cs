using Database.Entities;
using Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoForgeDbContext _context;

        public UserRepository(TodoForgeDbContext context)
        {
            _context = context;
        }

        public async Task Insert(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Username = createUserDto.Username,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
