using AutoMapper;
using MediatR;
using TaskTracker.Application.DTOs.Task;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Tasks.Commands;

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
        // Get the existing task from the repository using the Id
        var existing = await _repository.GetByIdAsync(request.Id);
        if (existing == null)
            throw new KeyNotFoundException($"Task with Id {request.Id} not found");

        // Map the request data to the existing task object
        _mapper.Map(request, existing);

        // Update the task in the repository
        var updated = await _repository.UpdateAsync(existing);

        // Map the updated task to a TaskResponseDto and return it
        return _mapper.Map<TaskResponseDto>(updated);
    }
}
