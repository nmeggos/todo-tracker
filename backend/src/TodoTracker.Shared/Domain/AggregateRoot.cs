using TodoTracker.Shared.Domain.Events;

namespace TodoTracker.Shared.Domain;

public abstract class AggregateRoot<TId> : Entity<TId>, IHaveAudit
{
    private readonly List<IDomainEvent> _domainEvents = new();
    
    protected AggregateRoot()
    {
    }
    
    protected AggregateRoot(TId id)
        : base(id)
    {
    }
    
    public string CreatedBy { get; protected set; }
    public DateTime CreatedOn { get; protected set; }
    public string LastModifiedBy { get; protected set; }
    public DateTime LastModifiedOn { get; protected set; }
    
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    public void ClearDomainEvents() => _domainEvents.Clear();
    
    
}