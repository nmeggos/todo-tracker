using Microsoft.Extensions.DependencyInjection;
using TodoTracker.Shared.CQRS;

namespace TodoTracker.Application;

public static class Registration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCqrs(assemblies: [typeof(ApplicationAssemblyReference).Assembly]);
        
        return services;
    }
}