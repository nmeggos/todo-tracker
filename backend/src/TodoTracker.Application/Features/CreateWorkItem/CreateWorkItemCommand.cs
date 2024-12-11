using Ardalis.GuardClauses;
using FluentValidation;
using Microsoft.Extensions.Logging;
using TodoTracker.Shared.CQRS.Commands;
using TodoTracker.Shared.Guards;
using TodoTracker.Domain;
using TodoTracker.Domain.WorkManagement;

namespace TodoTracker.Application.Features.CreateWorkItem;

public record CreateWorkItemCommand : ICommand<CreateWorkItemResponse>
{
    private CreateWorkItemCommand()
    {
        
    }

    private CreateWorkItemCommand(string title, string? description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
    }

    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public DateTime DueDate { get; init; }
    
    public static CreateWorkItemCommand Create(string title, string? description, DateTime dueDate)
    {
        return new CreateWorkItemCommand(title, description, dueDate);
    }
    
    public static CreateWorkItemCommand Create(CreateWorkItemRequest request)
    {
        return new CreateWorkItemCommand(request.Title, request.Description, request.DueDate);
    }
}

public class CreateWorkItemCommandValidator : AbstractValidator<CreateWorkItemCommand>
{
    public CreateWorkItemCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.DueDate).GreaterThanOrEqualTo(DateTime.Now);
    }
}

public class CreateWorkItemCommandHandler : ICommandHandler<CreateWorkItemCommand, CreateWorkItemResponse>
{
    private readonly IWorkItemRepository _workItemRepository;
    private readonly ILogger<CreateWorkItemCommandHandler> _logger;

    public CreateWorkItemCommandHandler(IWorkItemRepository workItemRepository, ILogger<CreateWorkItemCommandHandler> logger)
    {
        _logger = Guard.Against.MissingDependency(logger, nameof(logger));
        _workItemRepository = Guard.Against.MissingDependency(workItemRepository, nameof(workItemRepository));
    }

    public async Task<CreateWorkItemResponse> Handle(CreateWorkItemCommand request, CancellationToken cancellationToken)
    {
        var workItem = WorkItem.Create(request.Title, request.Description, request.DueDate);
        
        await _workItemRepository.AddAsync(workItem);
        
        _logger.LogInformation("WorkItem with Id {WorkItemId} created", workItem.Id);
        
        return new CreateWorkItemResponse(workItem.Id);
    }
}