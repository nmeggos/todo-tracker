namespace TodoTracker.Shared.CQRS.Queries;

public interface IQueryExecutor
{
    Task<TResult> SendAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default) 
        where TResult : notnull;
    
    IAsyncEnumerable<TResult> SendAsync<TResult>(IStreamQuery<TResult> query, CancellationToken cancellationToken = default) 
        where TResult : notnull;
}