using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TodoApp.Data.Models;

namespace TodoApp.Data.Database
{
    public class TodoAppDbContext : DbContext
    {
        private readonly ILogger<TodoAppDbContext> _logger;
        private readonly IConfiguration _configuration;

        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoAppDbContext(
            DbContextOptions<TodoAppDbContext> options, 
            IConfiguration configuration,
            ILogger<TodoAppDbContext> logger)
            : base(options)
        {
            _configuration = configuration;
            _logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration.GetConnectionString("TodoAppDbConnection");
            _logger.LogWarning(connection);
            optionsBuilder.UseNpgsql(connection);
        } 
    }
}