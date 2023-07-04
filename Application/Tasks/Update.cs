using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain;

namespace Application.Tasks
{
    public class Update
    {
        public class Command : IRequest
        {
            public TodoTask Todo { get; set; } // Takes ID as a parameter
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DatabaseContext _dbContext;

            public Handler(DatabaseContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cl)
            {
                var task = await _dbContext.TodoTasks.FindAsync(request.Todo.Id);
                
                if (task == null)
                {
                    throw new Exception("Task not found");
                }

                // Update fields if they are not null
                task.Title = request.Todo.Title ?? task.Title;
                task.Description = request.Todo.Description ?? task.Description;

                // Save changes to db
                _dbContext.TodoTasks.Update(task);
                await _dbContext.SaveChangesAsync();

                return Unit.Value;
            }

        }
    }
}
