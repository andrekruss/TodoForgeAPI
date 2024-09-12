﻿using Database.Entities;
using Dtos.BoardDtos;
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
    }
}
