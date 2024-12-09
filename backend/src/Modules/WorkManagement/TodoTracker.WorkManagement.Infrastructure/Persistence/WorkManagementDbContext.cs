using Microsoft.EntityFrameworkCore;
using TodoTracker.Shared.Infrastructure.Persistence;
using TodoTracker.workManagement.Domain;

namespace TodoTracker.WorkManagement.Infrastructure.Persistence;

public class WorkManagementDbContext : BaseDbContext
{
    public WorkManagementDbContext(DbContextOptions<WorkManagementDbContext> options) : base(options)
    {
    }
    
    public DbSet<WorkItem> WorkItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkManagementDbContext).Assembly);
    }
}