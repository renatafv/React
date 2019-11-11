using Microsoft.EntityFrameworkCore;

namespace FormApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        public DbSet<ContactItem> ContactItems { get; set; }
    }
}