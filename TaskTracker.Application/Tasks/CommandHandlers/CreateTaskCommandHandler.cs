using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs.Task;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Tasks.Commands;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Tasks.CommandHandlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskResponseDto>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TaskResponseDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TaskItem>(request);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<TaskResponseDto>(created);
        }
    }
}
