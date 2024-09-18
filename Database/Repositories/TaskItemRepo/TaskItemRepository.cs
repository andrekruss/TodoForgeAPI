using Database.Entities;
using Dtos.TaskItemDtos;
using Microsoft.EntityFrameworkCore;
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
        public async Task<TaskItemDto> Insert(int ownerId, CreateTaskItemDto createTaskDto)
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

            var taskItemDto = new TaskItemDto
            {
                Id = taskItem.Id,
                OwnerId = taskItem.OwnerId,
                BoardId = taskItem.BoardId,
                Title = taskItem.Title,
                Description = taskItem.Description,
                DeliveryDate = taskItem.DeliveryDate,
                DueDate = taskItem.DueDate,
                CreatedAt = taskItem.CreatedAt,
                UpdatedAt = taskItem.UpdatedAt
            };

            return taskItemDto;
        }

        public async Task<ICollection<TaskItemDto>> ListTasks(int ownerId, int boardId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.OwnerId == ownerId && t.BoardId == boardId)
                .Select(t => new TaskItemDto
                    {
                        Id = t.Id,
                        OwnerId = t.OwnerId,
                        BoardId = t.BoardId,
                        Title = t.Title,
                        Description = t.Description,
                        DeliveryDate = t.DeliveryDate,
                        DueDate = t.DueDate,
                        CreatedAt = t.CreatedAt,
                        UpdatedAt = t.UpdatedAt
                    }
                )
                .ToListAsync();

            return tasks;
        }
    }
}
