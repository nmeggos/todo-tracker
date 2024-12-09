using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using TodoTracker.Shared.CQRS;
using TodoTracker.Shared.Guards;
using TodoTracker.WorkManagement.Application.Features.CreateWorkItem;

namespace TodoTracker.WorkManagement.API.Controllers;

public class WorkItemController : ControllerBase
{
    private readonly IRequestExecutor _requestExecutor;
    private readonly ILogger<WorkItemController> _logger;

    public WorkItemController(IRequestExecutor requestExecutor, ILogger<WorkItemController> logger)
    {
        _logger = Guard.Against.MissingDependency(logger, nameof(logger));
        _requestExecutor = Guard.Against.MissingDependency(requestExecutor, nameof(requestExecutor));
    }
    
    [HttpGet("work-items")]
    public async Task<IActionResult> GetWorkItems()
    {
        _logger.LogInformation("Receiving get work items request");
        
        return Ok("No work items yet");
    }
    
    [HttpPost("work-items")]
    public async Task<IActionResult> CreateWorkItem([FromBody] CreateWorkItemRequest request)
    {
        _logger.LogInformation("Receiving create work item with title {Title}", request.Title);
        
        var command = CreateWorkItemCommand.Create(request);
        var result = await _requestExecutor.SendAsync(command);
        
        return Ok(result);
    }
    
}