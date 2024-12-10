namespace TodoTracker.Domain.WorkManagement;

public interface IWorkItemRepository
{
    Task<WorkItem> GetAsync(WorkItemId workItemId);
    Task<List<WorkItem>> GetAllAsync();
    Task AddAsync(WorkItem workItem);
}