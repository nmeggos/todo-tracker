namespace TodoTracker.Shared.Domain;

public interface IHaveAudit
{
    public string CreatedBy { get; }
    public DateTimeOffset CreatedOn { get; }
    public string? LastModifiedBy { get; }
    public DateTimeOffset? LastModifiedOn { get; }
}