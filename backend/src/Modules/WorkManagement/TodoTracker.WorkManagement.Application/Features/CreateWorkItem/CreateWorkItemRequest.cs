namespace TodoTracker.WorkManagement.Application.Features.CreateWorkItem;

public record CreateWorkItemRequest
{
    public string Title { get; init; }
    public string? Description { get; init; }
    public DateTime DueDate { get; init; }
}