namespace TodoTracker.Shared.Domain.Events;

public interface IDomainEventDispatcher
{
    Task DispatchAsync<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken)
        where TDomainEvent : IDomainEvent;
}