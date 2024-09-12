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
    }
}
