using MediatR;
using TodoTracker.Shared.CQRS.Commands;
using TodoTracker.Shared.CQRS.Queries;

namespace TodoTracker.Shared.CQRS;

public class RequestExecutor : IRequestExecutor
{
    private readonly IMediator _mediator;

    public RequestExecutor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default) where TResult : notnull
    {
        return await _mediator.Send(command, cancellationToken);
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