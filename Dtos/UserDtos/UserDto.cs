using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserDto(int id, string username, string email, bool isActive, DateTime createdAt)
        {
            Id = id;
            Username = username;
            Email = email;
            IsActive = isActive;
            CreatedAt = createdAt;
        }
    }
}
