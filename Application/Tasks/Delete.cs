using Domain;
using MediatR;

namespace Application.Tasks
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; } // Takes ID as a parameter
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
                var taskToDelete = await _dbContext.TodoTasks.FindAsync(request.Id);

                if (taskToDelete == null)
                {
                    throw new Exception("Task not found");
                }

                _dbContext.TodoTasks.Remove(taskToDelete);
                await _dbContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
