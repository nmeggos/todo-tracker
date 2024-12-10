using Microsoft.AspNetCore.Routing;

namespace TodoTracker.Shared.Endpoints;

public interface IEndpointDefinition
{
    void MapEndpoint(IEndpointRouteBuilder routeBuilder);
}