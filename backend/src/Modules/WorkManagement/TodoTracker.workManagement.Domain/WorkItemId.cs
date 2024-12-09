using TodoTracker.Shared.Domain;

namespace TodoTracker.workManagement.Domain;

public record WorkItemId : StronglyTypedId<Guid>
{
    public WorkItemId(Guid value) : base(value)
    {
    }
    
    public static WorkItemId New => new(Guid.NewGuid());
    public static WorkItemId From(Guid workItemId) => new(workItemId);
}