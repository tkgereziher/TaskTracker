using AutoMapper;
using TaskTracker.Application.DTOs.Task;
using TaskTracker.Domain.Entities;
using TaskTracker.Application.Tasks.Commands;

namespace TaskTracker.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskResponseDto>();
            CreateMap<TaskRequestDto, TaskItem>();

            CreateMap<CreateTaskCommand, TaskItem>();
            CreateMap<UpdateTaskCommand, TaskItem>();
        }
    }
}
