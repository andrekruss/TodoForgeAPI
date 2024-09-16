using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.TaskItemDtos
{
    public class CreateTaskItemDto
    {
        public int BoardId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public CreateTaskItemDto(int boardId, string title, string description, DateTime dueDate) 
        { 
            BoardId = boardId;
            Title = title;
            Description = description;
            DeliveryDate = null;
            DueDate = dueDate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
