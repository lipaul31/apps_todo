using Microsoft.EntityFrameworkCore;
using TodoApp.Repository.Models;

namespace TodoApp.Repository.Database
{
    public class TodoAppDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options)
            :base(options) { }
    }
}