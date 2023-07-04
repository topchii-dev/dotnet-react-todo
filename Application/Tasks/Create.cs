
using Domain;
using MediatR;
using TodoApp.Domain;

namespace Application.Tasks
{

    public class Create
    {

        public class Command : IRequest // Command does not return anything
        {
            public TodoTask? Todo {get; set;}
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DatabaseContext _dbContext;

            public Handler(DatabaseContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cl)
            {
                _dbContext.TodoTasks.Add(request.Todo);

                await _dbContext.SaveChangesAsync();

                return Unit.Value;
            }

        }
    }

}