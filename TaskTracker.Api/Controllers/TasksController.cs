using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Tasks.Commands;
using TaskTracker.Application.Tasks.Queries;
using TaskTracker.Application.DTOs.Task;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetAll()
        {
            var tasks = await _mediator.Send(new GetAllTasksQuery());
            return Ok(tasks);
        }

        // GET: api/tasks/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TaskResponseDto>> GetById(Guid id)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery(id));
            return task is null ? NotFound() : Ok(task);
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskResponseDto>> Create([FromBody] CreateTaskCommand command)
        {
            var createdTask = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TaskResponseDto>> Update(Guid id, [FromBody] UpdateTaskCommand command)
        {
            // Manually set the Id in the command from the URL parameter
            command.Id = id;

            try
            {
                // Send the command to MediatR to update the task
                var updatedTask = await _mediator.Send(command);

                // Return the updated task in the response
                return Ok(updatedTask);
            }
            catch (KeyNotFoundException)
            {
                // If the task wasn't found, return a 404 Not Found
                return NotFound();
            }
        }


        // DELETE: api/tasks/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteTaskCommand(id));
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
