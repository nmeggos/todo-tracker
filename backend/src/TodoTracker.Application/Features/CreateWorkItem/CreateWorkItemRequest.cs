namespace TodoTracker.Application.Features.CreateWorkItem;

public record CreateWorkItemRequest
{
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public DateTime DueDate { get; init; }
}