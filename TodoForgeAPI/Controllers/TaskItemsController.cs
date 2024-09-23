using Contracts.TaskItem;
using Database.Entities;
using Database.Repositories.TaskItemRepo;
using Dtos.TaskItemDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TodoForgeAPI.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemsController(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        [HttpPost]
        [Authorize]
        [Route("create-task")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskItemRequest request)
        {
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var createTaskItemDto = new CreateTaskItemDto(
                request.BoardId,
                request.Title,
                request.Description,
                request.DueDate
            );

            var taskItemDto = await _taskItemRepository.Insert(userId, createTaskItemDto);

            return CreatedAtAction(null, taskItemDto);
        }

        [HttpGet]
        [Authorize]
        [Route("list-tasks/{boardId}")]
        public async Task<IActionResult> GetTasksByBoard([FromRoute] int boardId)
        {
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var tasks = await _taskItemRepository.ListTasks(userId, boardId);

            if (tasks == null)
                return NotFound();
            return Ok(tasks);
        }

        [HttpDelete]
        [Authorize]
        [Route("delete-task/{taskId}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int taskId)
        {
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _taskItemRepository.Delete(userId, taskId);
            return NoContent();
        }
    }
}
