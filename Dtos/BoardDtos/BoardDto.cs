using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.BoardDtos
{
    public class BoardDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BoardDto(int ownerId, string title, string description)
        {
            OwnerId = ownerId;
            Title = title;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public BoardDto(int id, int ownerId, string title, string description, DateTime createdAt, DateTime updatedAt) 
        {
            Id = id;
            OwnerId = ownerId;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
