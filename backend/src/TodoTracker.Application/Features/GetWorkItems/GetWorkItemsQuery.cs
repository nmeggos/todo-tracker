using Ardalis.GuardClauses;
using TodoTracker.Application.Models;
using TodoTracker.Domain.WorkManagement;
using TodoTracker.Shared.CQRS.Queries;
using TodoTracker.Shared.Guards;
using NotFoundException = TodoTracker.Shared.Domain.Exceptions.NotFoundException;

namespace TodoTracker.Application.Features.GetWorkItems;

public record GetWorkItemsQuery : IQuery<IEnumerable<WorkItemModel>>
{
    
}

public class GetWorkItemsQueryHandler : IQueryHandler<GetWorkItemsQuery, IEnumerable<WorkItemModel>>
{
    private readonly IWorkItemRepository _workItemRepository;

    public GetWorkItemsQueryHandler(IWorkItemRepository workItemRepository)
    {
        _workItemRepository = Guard.Against.MissingDependency(workItemRepository, nameof(workItemRepository));
    }

    public async Task<IEnumerable<WorkItemModel>> Handle(GetWorkItemsQuery request, CancellationToken cancellationToken)
    {
        var workItems = await _workItemRepository.GetAllAsync();
        
        Guard.Against.NotFound(workItems, new NotFoundException("No work items found."));
        
        return workItems.Select(wi => new WorkItemModel
        {
            Id = wi.Id.ToString(),
            Title = wi.Title,
            Description = wi.Description,
            Status = wi.Status.ToString()
        });
    }
}