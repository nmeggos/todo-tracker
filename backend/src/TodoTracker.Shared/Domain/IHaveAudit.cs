namespace TodoTracker.Shared.Domain;

public interface IHaveAudit
{
    public string CreatedBy { get; }
    public DateTime CreatedOn { get; }
    public string LastModifiedBy { get; }
    public DateTime LastModifiedOn { get; }
}