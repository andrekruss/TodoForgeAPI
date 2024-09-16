using Contracts.TaskItem;
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

            await _taskItemRepository.Insert(userId, createTaskItemDto);

            return Created();
        }
    }
}
