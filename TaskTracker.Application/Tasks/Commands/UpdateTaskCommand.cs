using MediatR;
using TaskTracker.Application.DTOs.Task;

namespace TaskTracker.Application.Tasks.Commands
{
    public class UpdateTaskCommand : IRequest<TaskResponseDto>
    {
        public Guid Id { get; set; }
        public TaskRequestDto TaskRequestDto { get; set; }

        // Constructor
        public UpdateTaskCommand(TaskRequestDto taskRequestDto)
        {
            TaskRequestDto = taskRequestDto;
        }
    }
}
