using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoApp.Data.Models;

namespace TodoApp.Data.Database
{
    public class TodoAppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration.GetConnectionString("TodoAppDbConnection");
            optionsBuilder.UseNpgsql(connection);
        }
    }
}