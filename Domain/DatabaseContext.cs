using Microsoft.EntityFrameworkCore;
using TodoApp.Domain;

namespace Domain
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options){}

        public DbSet<TodoTask>? TodoTasks {get; set;}
    }
}