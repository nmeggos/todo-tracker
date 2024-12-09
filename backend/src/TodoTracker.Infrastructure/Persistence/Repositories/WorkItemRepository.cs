using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using TodoTracker.Domain;
using TodoTracker.Domain.WorkManagement;
using TodoTracker.Shared.Guards;

namespace TodoTracker.Infrastructure.Persistence.Repositories;

public class WorkItemRepository : IWorkItemRepository
{
    private readonly TodoTrackerDbContext _dbContext;

    public WorkItemRepository(TodoTrackerDbContext dbContext)
    {
        _dbContext = Guard.Against.MissingDependency(dbContext, nameof(dbContext));
    }

    public async Task<WorkItem> GetAsync(WorkItemId workItemId)
    {
        return await _dbContext.WorkItems.FindAsync(workItemId);
    }

    public async Task<List<WorkItem>> GetAllAsync()
    {
        return await _dbContext.WorkItems.ToListAsync();
    }

    public Task AddAsync(WorkItem workItem)
    {
        _dbContext.WorkItems.Add(workItem);
        _dbContext.SaveChanges();
        return Task.CompletedTask;
    }
}