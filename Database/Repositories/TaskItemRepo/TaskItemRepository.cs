using Database.Entities;
using Dtos.TaskItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.TaskItemRepo
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly TodoForgeDbContext _context;

        public TaskItemRepository(TodoForgeDbContext context) 
        { 
            _context = context;
        }
        public async Task Insert(int ownerId, CreateTaskItemDto createTaskDto)
        {

            var taskItem = new TaskItem
            {
                OwnerId = ownerId,
                BoardId = createTaskDto.BoardId,
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,
                DueDate = createTaskDto.DueDate,
                CreatedAt = createTaskDto.CreatedAt,
                UpdatedAt = createTaskDto.UpdatedAt
            };

            await _context.Tasks.AddAsync(taskItem);
            await _context.SaveChangesAsync();
        }
    }
}
