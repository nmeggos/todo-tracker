using MediatR;

namespace TodoTracker.Shared.CQRS.Commands;

public class CommandExecutor : ICommandExecutor
{
    private readonly IMediator _mediator;

    public CommandExecutor(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default) where TResult : notnull
    {
        return await _mediator.Send(command, cancellationToken);
    }
}