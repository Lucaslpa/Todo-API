using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Infra;

public class SqlServerContext( DbContextOptions<SqlServerContext> options ) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerContext).Assembly);
    }

}
