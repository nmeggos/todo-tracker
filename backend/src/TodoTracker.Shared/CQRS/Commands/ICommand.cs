
using MediatR;

namespace TodoTracker.Shared.CQRS.Commands;

public interface ICommand<out TResult> : IRequest<TResult> where TResult : notnull
{
    
}

public interface ICommand : ICommand<Unit>
{
    
}