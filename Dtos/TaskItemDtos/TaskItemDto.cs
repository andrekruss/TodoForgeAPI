﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.TaskItemDtos
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public DateTime DeliveryDate { get; set;}
        public DateTime DueDate { get; set;}
        public DateTime CreatedAt { get; set;}
        public DateTime UpdatedAt { get; set;}
    }
}
