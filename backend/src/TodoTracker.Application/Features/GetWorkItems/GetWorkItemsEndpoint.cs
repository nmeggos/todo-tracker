using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TodoTracker.Shared.CQRS.Queries;
using TodoTracker.Shared.Endpoints;

namespace TodoTracker.Application.Features.GetWorkItems;

public class GetWorkItemsEndpoint : IEndpointDefinition
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/work-items", async (
            IQueryExecutor queryExecutor) =>
        {
            var result = await queryExecutor.SendAsync(new GetWorkItemsQuery());
            
            return Results.Ok(result);
        });
    }
}