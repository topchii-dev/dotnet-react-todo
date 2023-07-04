using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using MediatR;
using TodoApp.Domain;

namespace TodoApp.Controllers 
{

    [ApiController]
    
    [Route("api/")]

    public class TodoTaskController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        /* Read operations */

        [HttpGet("tasks")]
        public async Task<ActionResult<List<Domain.TodoTask>>> GetTasks(CancellationToken cl)
        {
            return Ok(await Mediator.Send(new Application.Tasks.ListAll.Query()));
        }

        [HttpGet("tasks/{id}")]
        public async Task<ActionResult<Domain.TodoTask>> GetTask(Guid id, CancellationToken cl)
        {
            return Ok(await Mediator.Send(new Application.Tasks.ViewOne.Query{Id=id}));
        }

        /* Update operation */

        [HttpPut("tasks/{id}")]
        public async Task<ActionResult<TodoTask>> UpdateTask(Guid id, TodoTask todoTask)
        {
            return Ok(await Mediator.Send(new Application.Tasks.Update.Command{Todo=todoTask}));
        }

        /* Create operation */

        [HttpPost("tasks/")]
        public async Task<ActionResult<TodoTask>> CreateTask (TodoTask task, CancellationToken cl)
        {
            return Ok(await Mediator.Send(new Application.Tasks.Create.Command{Todo=task}));
        }

        /* Delete operation */

        [HttpDelete("tasks/{id}")]
        public async Task<ActionResult> DeleteTask (Guid id, CancellationToken cl)
        {
            return Ok(await Mediator.Send(new Application.Tasks.Delete.Command{Id=id}));
        }
    }
}