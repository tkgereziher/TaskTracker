using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Tasks.Commands;
using System.Collections.Generic;

namespace TaskTracker.Application.Tasks.CommandHandlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ITaskRepository _repository;

        public DeleteTaskCommandHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Task with Id {request.Id} not found");

            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
