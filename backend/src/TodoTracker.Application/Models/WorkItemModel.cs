namespace TodoTracker.Application.Models;

public class WorkItemModel
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Status { get; set; }
}