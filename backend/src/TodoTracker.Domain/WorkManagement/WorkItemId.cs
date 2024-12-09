using TodoTracker.Shared.Domain;

namespace TodoTracker.Domain.WorkManagement;

public record WorkItemId : StronglyTypedId<Guid>
{
    public WorkItemId(Guid value) : base(value)
    {
    }
    
    public static WorkItemId New => new(Guid.NewGuid());
    public static WorkItemId From(Guid workItemId) => new(workItemId);
}