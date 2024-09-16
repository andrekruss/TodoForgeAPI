using Dtos.TaskItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.TaskItemRepo
{
    public interface ITaskItemRepository
    {
        Task Insert(int ownerId, CreateTaskItemDto createTaskDto);
    }
}
