using Database.Entities;
using Dtos.BoardDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.BoardRepo
{
    public class BoardRepository : IBoardRepository
    {
        private readonly TodoForgeDbContext _context;

        public BoardRepository(TodoForgeDbContext context) 
        {
            _context = context;
        }

        public async Task CreateBoard(BoardDto boardDto)
        {

            var board = new Board
            {
                OwnerId = boardDto.OwnerId,
                Title = boardDto.Title,
                Description = boardDto.Description,
                CreatedAt = boardDto.CreatedAt,
                UpdatedAt = boardDto.UpdatedAt
            };

            await _context.Boards.AddAsync(board); 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBoardById(int ownerId, int boardId)
        {
            var board = await _context.Boards.FirstOrDefaultAsync(b => b.Id == boardId && b.OwnerId == ownerId);

            if (board == null) 
                return;

            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<BoardDto>> GetAllBoards(int ownerId)
        {
            var boards = await _context.Boards
                .Where(b => b.OwnerId == ownerId)
                .Select(b => new BoardDto(
                    b.Id,
                    b.OwnerId,
                    b.Title,
                    b.Description,
                    b.CreatedAt,
                    b.UpdatedAt
                ))
                .ToListAsync();

            return boards;
        }
    }
}
