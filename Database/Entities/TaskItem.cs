﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public int BoardId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public DateTime DeliveryDate { get; set; }
        public DateTime DueDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("OwnerId")]
        public User Owner { get; set; }
        [ForeignKey("BoardId")]
        public Board Board { get; set; }
    }
}
