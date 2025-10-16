using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Application.DTOs.Task
{
    public class TaskRequestDto
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
