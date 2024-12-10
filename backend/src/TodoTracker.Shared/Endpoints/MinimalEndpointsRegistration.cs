using System.Reflection;
using Microsoft.AspNetCore.Routing;

namespace TodoTracker.Shared.Endpoints;

public static class MinimalEndpointsRegistration
{
    public static IEndpointRouteBuilder MapEndpoints(
        this IEndpointRouteBuilder builder,
        params Assembly[] scanAssemblies)
    {
        var assemblies = scanAssemblies.Any() ? scanAssemblies : AppDomain.CurrentDomain.GetAssemblies();

        var endpoints = assemblies.SelectMany(x => x.GetTypes()).Where(t =>
            t.IsClass && !t.IsAbstract && !t.IsGenericType && !t.IsInterface
            && t.GetConstructor(Type.EmptyTypes) != null
            && typeof(IEndpointDefinition).IsAssignableFrom(t)).ToList();

        foreach (var endpoint in endpoints)
        {
            var instantiatedType = (IEndpointDefinition)Activator.CreateInstance(endpoint)!;
            instantiatedType.MapEndpoint(builder);
        }

        return builder;
    }
}