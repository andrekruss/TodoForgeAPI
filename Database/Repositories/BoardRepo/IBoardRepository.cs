using Dtos.BoardDtos;
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
    }
}
