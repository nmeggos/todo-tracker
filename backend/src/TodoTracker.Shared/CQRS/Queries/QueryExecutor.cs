using MediatR;

namespace TodoTracker.Shared.CQRS.Queries;

public class QueryExecutor : IQueryExecutor
{
    private readonly IMediator _mediator;

    public QueryExecutor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TResult> SendAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default) where TResult : notnull
    {
        return await _mediator.Send(query, cancellationToken);
    }

    public IAsyncEnumerable<TResult> SendAsync<TResult>(IStreamQuery<TResult> query, CancellationToken cancellationToken = default) where TResult : notnull
    {
        return _mediator.CreateStream(query, cancellationToken);
    }
}