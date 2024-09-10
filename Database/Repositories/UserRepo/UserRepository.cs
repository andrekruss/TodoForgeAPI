using Database.Entities;
using Dtos.UserDtos;
using Microsoft.EntityFrameworkCore;
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

        public async Task Insert(UserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,
                IsActive = userDto.IsActive,
                CreatedAt = userDto.CreatedAt,
                UpdatedAt = userDto.UpdatedAt
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(email) == true);

            if (user == null)
                return null;

            var userDto = new UserDto(
                user.Username,
                user.Email,
                user.Password,
                user.IsActive,
                user.CreatedAt,
                user.UpdatedAt
            );

            return userDto;
        }
    }
}
