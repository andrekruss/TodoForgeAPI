﻿using Dtos.BoardDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.BoardRepo
{
    public interface IBoardRepository
    {
        Task CreateBoard(BoardDto boardDto);
        Task DeleteBoardById(int onwerId, int boardId);
        Task<ICollection<BoardDto>> GetAllBoards(int ownerId);
        Task<BoardDto> PatchBoard(int ownerId, int boardId, BoardPatchDto boardPatchDto);
    }
}
