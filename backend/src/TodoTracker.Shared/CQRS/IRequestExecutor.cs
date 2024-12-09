using TodoTracker.Shared.CQRS.Commands;
using TodoTracker.Shared.CQRS.Queries;

namespace TodoTracker.Shared.CQRS;

public interface IRequestExecutor : ICommandExecutor, IQueryExecutor
{
    
}