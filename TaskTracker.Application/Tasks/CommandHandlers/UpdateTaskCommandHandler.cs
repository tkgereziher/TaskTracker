using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs.Task;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;
using TaskTracker.Application.Tasks.Commands;

namespace TaskTracker.Application.Tasks.CommandHandlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskResponseDto>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TaskResponseDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the task from the repository using the Id from the command
            var existingTask = await _repository.GetByIdAsync(request.Id);
            if (existingTask == null)
                throw new KeyNotFoundException($"Task with Id {request.Id} not found");

            // Map the task request DTO to the existing task (excluding the Id)
            _mapper.Map(request.TaskRequestDto, existingTask);

            // Update the task in the repository
            var updatedTask = await _repository.UpdateAsync(existingTask);

            // Return the updated task as a TaskResponseDto
            return _mapper.Map<TaskResponseDto>(updatedTask);
        }
    }
}
