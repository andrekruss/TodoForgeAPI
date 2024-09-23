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
        Task<TaskItemDto> GetTaskItemById(int ownerId, int taskId);
        Task<TaskItemDto> Insert(int ownerId, CreateTaskItemDto createTaskDto);
        Task<ICollection<TaskItemDto>> ListTasks(int ownerId, int boardId);
        Task Delete(int ownerId, int taskId);
    }
}
