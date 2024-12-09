using TodoTracker.Shared.Domain;

namespace TodoTracker.workManagement.Domain;

public class WorkItem : AggregateRoot<WorkItemId>
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Status Status { get; private set; }
    public DateTime DueDate { get; private set; }
}

public record Status
{
    private Status()
    {
        
    }
    
    private Status(string value)
    {
        Value = value;
    }
    
    public string Value { get; private set; }
    
    public static Status New => new("New");
    public static Status InProgress => new("InProgress");
    public static Status Completed => new("Completed");
    
    public static Status From(string value) => new(value);

    public override string? ToString() => Value;
}