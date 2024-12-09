using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using TodoTracker.Shared.Guards;
using TodoTracker.workManagement.Domain;

namespace TodoTracker.WorkManagement.Infrastructure.Persistence.Repositories;

public class WorkItemRepository : IWorkItemRepository
{
    private readonly WorkManagementDbContext _dbContext;

    public WorkItemRepository(WorkManagementDbContext dbContext)
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