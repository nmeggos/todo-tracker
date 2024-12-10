namespace TodoTracker.Shared.CQRS.Commands;

public interface ICommandExecutor
{
    Task<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default) 
        where TResult : notnull;
}