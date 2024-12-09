using Microsoft.Extensions.DependencyInjection;
using TodoTracker.Shared.CQRS;

namespace TodoTracker.WorkManagement.Application;

public static class Registration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCqrs(assemblies: new[] { typeof(ApplicationAssemblyReference).Assembly });
        
        return services;
    }
}