using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs.Task;

namespace TaskTracker.Application.Tasks.Queries
{
    public class GetTaskByIdQuery : IRequest<TaskResponseDto?>
    {
        public Guid Id { get; set; }
        public GetTaskByIdQuery(Guid id) => Id = id;
    }
}
