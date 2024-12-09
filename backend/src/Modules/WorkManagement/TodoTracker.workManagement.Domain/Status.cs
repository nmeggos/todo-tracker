namespace TodoTracker.workManagement.Domain;

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