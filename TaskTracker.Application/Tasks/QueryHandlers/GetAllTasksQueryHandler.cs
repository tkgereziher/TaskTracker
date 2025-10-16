using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs.Task;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Tasks.Queries;

namespace TaskTracker.Application.Tasks.QueryHandlers
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskResponseDto>>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public GetAllTasksQueryHandler(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskResponseDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
        }
    }
}
