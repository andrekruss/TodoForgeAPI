using Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task Insert(CreateUserDto createUserDto);
    }
}
