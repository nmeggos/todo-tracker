using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TodoTracker.Shared.CQRS.Commands;
using TodoTracker.Shared.Endpoints;

namespace TodoTracker.Application.Features.CreateWorkItem;

public class CreateWorkItemEndpoint : IEndpointDefinition
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("/work-items", async (
            [FromBody] CreateWorkItemRequest request,
            ICommandExecutor commandExecutor) =>
        {
            var result = await commandExecutor.SendAsync(CreateWorkItemCommand.Create(request));

            return Results.Created($"/work-items/{result.Id}", result);
        })
        .MapToApiVersion(1);
    }
}