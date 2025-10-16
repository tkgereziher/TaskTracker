using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs.Task;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Tasks.Queries;

namespace TaskTracker.Application.Tasks.QueryHandlers
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskResponseDto?>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public GetTaskByIdQueryHandler(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TaskResponseDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            return entity == null ? null : _mapper.Map<TaskResponseDto>(entity);
        }
    }
}
