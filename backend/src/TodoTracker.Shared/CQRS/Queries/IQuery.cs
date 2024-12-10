using MediatR;

namespace TodoTracker.Shared.CQRS.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
    where TResult : notnull
{
    
}

public interface IStreamQuery<out TResult> : IStreamRequest<TResult>
    where TResult : notnull
{
    
}