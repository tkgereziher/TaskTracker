using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TaskItem>> GetTasksAsync() => _repository.GetAllAsync();
        public Task<TaskItem?> GetTaskAsync(Guid id) => _repository.GetByIdAsync(id);
        public Task<TaskItem> CreateTaskAsync(TaskItem task) => _repository.AddAsync(task);
        public Task<TaskItem> UpdateTaskAsync(TaskItem task) => _repository.UpdateAsync(task);
        public Task DeleteTaskAsync(Guid id) => _repository.DeleteAsync(id);
    }
}
