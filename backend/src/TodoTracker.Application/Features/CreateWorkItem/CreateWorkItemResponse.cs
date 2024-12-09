using TodoTracker.Domain;
using TodoTracker.Domain.WorkManagement;

namespace TodoTracker.Application.Features.CreateWorkItem;

public record CreateWorkItemResponse(WorkItemId Id);