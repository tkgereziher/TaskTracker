using MediatR;
using System;

namespace TaskTracker.Application.Tasks.Commands
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteTaskCommand(Guid id) => Id = id;
    }
}
