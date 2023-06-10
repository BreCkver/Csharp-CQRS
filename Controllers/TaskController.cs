using CSharp_CQRS_Example.Application.DTOs;
using CSharp_CQRS_Example.Infrastructure.Commands;
using CSharp_CQRS_Example.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_CQRS_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItemDTO>> GetAll()
        {
            return await _mediator.Send(new GetAllTasksQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDTO>> GetById(int id)
        {
            var query = new GetTaskByIdQuery(id);
            var taskItem = await _mediator.Send(query);

            if(taskItem == null || taskItem.Id <= 0)
            {
                return NotFound();
            }
            return taskItem;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemDTO>> Create(CreateTaskCommand command)
        {            
            var taskItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new {  id = taskItem.Id}, taskItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            var taskItem = await _mediator.Send(command);
            if(taskItem == null || taskItem.Id <= 0)
            {
                return NotFound();
            }
            return NoContent();
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteTaskCommand(id));
            if(!result)
            {
                return NotFound();
            }
            return NoContent();
        } 
    }
}