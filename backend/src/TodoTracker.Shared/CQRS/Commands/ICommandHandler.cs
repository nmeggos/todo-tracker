using MediatR;

namespace TodoTracker.Shared.CQRS.Commands;

public interface ICommandHandler<in TCommand, TResult> :IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
    where TResult : notnull
{
}

public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand
{
}