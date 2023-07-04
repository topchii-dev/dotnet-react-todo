using Domain;
using MediatR;
using TodoApp.Domain;

namespace Application.Tasks
{
    public class ViewOne
    {
        public class Query : IRequest<TodoTask> // Return one Todo entry
        {
            public Guid Id { get; set; } // Takes ID as a parameter
        }

        public class Handler : IRequestHandler<Query, TodoTask>
        {
            private readonly DatabaseContext _dbContext;

            public Handler(DatabaseContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<TodoTask> Handle(Query request, CancellationToken cl)
            {
                return await _dbContext.TodoTasks.FindAsync(request.Id);
            }
        }
    }
}
