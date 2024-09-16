using Contracts.Board;
using Database.Repositories.BoardRepo;
using Dtos.BoardDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TodoForgeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly IBoardRepository _boardRepository;

        public BoardsController(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        [HttpGet]
        [Authorize]
        [Route("list-boards")]
        public async Task<IActionResult> ListBoards()
        {
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var boards = await _boardRepository.GetAllBoards(userId);

            if (boards == null)
                return NotFound();

            return Ok(boards);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBoard(CreateBoardRequest request)
        {

            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var boardDto = new BoardDto(
                userId,
                request.Title,
                request.Description
            );

           await  _boardRepository.CreateBoard(boardDto);

            return Ok("Board created successfully");
        }

        [HttpDelete]
        [Authorize]
        [Route("{boardId}")]
        public async Task<IActionResult> DeleteBoard(int boardId)
        {
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _boardRepository.DeleteBoardById(userId, boardId);

            return NoContent();
        }

        [HttpPatch]
        [Authorize]
        [Route("update-board/{boardId}")]
        public async Task<IActionResult> PatchBoard([FromRoute] int boardId, [FromBody] UpdateBoardRequest request)
        {
            var userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var boardPatchDto = new BoardPatchDto(
                request.Title,
                request.Description,
                DateTime.UtcNow
            );

            var boardDto = await _boardRepository.PatchBoard(userId, boardId, boardPatchDto);

            return Ok(boardDto);
        }
    }
}
