using Ardalis.GuardClauses;
using TodoTracker.Shared.Domain;

namespace TodoTracker.Domain;

public class WorkItem : AggregateRoot<WorkItemId>
{
    private WorkItem()
    {
        
    }

    private WorkItem(string title, string? description, DateTime dueDate)
    {
        Id = WorkItemId.New;
        Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
        Description = description ?? string.Empty;
        DueDate = Guard.Against.Default(dueDate, nameof(dueDate));
        Status = Status.New;
        
        CreatedBy = "System";
        CreatedOn = DateTimeOffset.UtcNow;
    }

    public string Title { get; private set; }
    public string? Description { get; private set; }
    public Status Status { get; private set; }
    public DateTimeOffset DueDate { get; private set; }
    
    public static WorkItem Create(string title, string? description, DateTime dueDate)
    {
        return new WorkItem(title, description, DateTime.SpecifyKind(dueDate, DateTimeKind.Utc));
    }
}