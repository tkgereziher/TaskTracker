using MediatR;
using TaskTracker.Application.DTOs.Task;
using System.Collections.Generic;

namespace TaskTracker.Application.Tasks.Queries
{
    public class GetAllTasksQuery : IRequest<IEnumerable<TaskResponseDto>>
    {
    }
}
