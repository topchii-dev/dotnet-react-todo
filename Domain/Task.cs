using Microsoft.EntityFrameworkCore;

namespace TodoApp.Domain
{

    public class TodoTask 
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeadlineDate { get; set; }
    }
}