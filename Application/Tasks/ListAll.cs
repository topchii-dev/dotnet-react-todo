using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain;

namespace Application.Tasks
{
    public class ListAll
    {
        public class Query : IRequest<List<TodoTask>> {} // Return list of Todos

        public class Handler : IRequestHandler<Query, List<TodoTask>>
        {
            private readonly DatabaseContext _dbContext;

            public Handler(DatabaseContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<List<TodoTask>> Handle(Query request, CancellationToken cl)
            {
                return await _dbContext.TodoTasks.ToListAsync();
            }
        }
    }
}
