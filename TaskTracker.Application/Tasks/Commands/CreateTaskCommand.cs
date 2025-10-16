using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs.Task;

namespace TaskTracker.Application.Tasks.Commands
{
        public class CreateTaskCommand : IRequest<TaskResponseDto>
        {
            public string Title { get; set; } = string.Empty;
            public string? Description { get; set; }
            public bool IsCompleted { get; set; } = false;
        }
}
