using MediatR;
using TaskTracker.Application.DTOs.Task;
using System;

namespace TaskTracker.Application.Tasks.Commands
{
    public class UpdateTaskCommand : IRequest<TaskResponseDto>
    {
        public Guid Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }

        public UpdateTaskCommand(Guid id, string title, string? description, bool isCompleted)
        {
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }
    }
}
