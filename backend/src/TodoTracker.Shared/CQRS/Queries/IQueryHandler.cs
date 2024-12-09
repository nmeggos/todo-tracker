using MediatR;

namespace TodoTracker.Shared.CQRS.Queries;

public interface IQueryHandler<in TQuery, TResult> 
    : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult> 
    where TResult : notnull
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}

public interface IStreamQueryHandler<in TQuery, out TResult> 
    : IStreamRequestHandler<TQuery,TResult>
    where TQuery : IStreamQuery<TResult> 
    where TResult : notnull
{
    IAsyncEnumerable<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}