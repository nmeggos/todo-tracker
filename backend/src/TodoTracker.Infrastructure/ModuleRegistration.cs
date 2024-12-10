using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoTracker.Application;
using TodoTracker.Infrastructure.Persistence;

namespace TodoTracker.Infrastructure;

public static class ModuleRegistration
{
    public static IServiceCollection AddWorkManagementModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddApplication();
        
        return services;
    }
}