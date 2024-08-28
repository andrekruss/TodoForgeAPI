using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UserDtos
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public CreateUserDto(string username, string email, string password)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }
    }
}
