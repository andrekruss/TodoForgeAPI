using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BoardDtos
{
    public class BoardPatchDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BoardPatchDto(string title, string description, DateTime updatedAt)
        {
            Title = title;
            Description = description;
            UpdatedAt = updatedAt;
        }
    }
}
