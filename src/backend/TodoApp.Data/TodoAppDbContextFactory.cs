using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TodoApp.Data.Database;

namespace TodoApp.Data
{
    internal class TodoAppDbContextFactory : IDesignTimeDbContextFactory<TodoAppDbContext>
    {
        public TodoAppDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var factory = LoggerFactory
                .Create(c => c.SetMinimumLevel(LogLevel.Trace));
            var logger = factory.CreateLogger<TodoAppDbContext>();

            var optionsBuilder = new DbContextOptionsBuilder<TodoAppDbContext>();
            return new TodoAppDbContext(
                optionsBuilder.Options, 
                builder.Build(),
                logger, 
                factory);
        }
    }
}
