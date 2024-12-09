using Microsoft.EntityFrameworkCore;
using TodoTracker.Domain;
using TodoTracker.Domain.WorkManagement;
using TodoTracker.Shared.Infrastructure.Persistence;

namespace TodoTracker.Infrastructure.Persistence;

public class TodoTrackerDbContext : BaseDbContext
{
    public TodoTrackerDbContext(DbContextOptions<TodoTrackerDbContext> options) : base(options)
    {
    }
    
    public DbSet<WorkItem> WorkItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoTrackerDbContext).Assembly);
    }
}