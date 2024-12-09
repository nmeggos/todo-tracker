using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoTracker.WorkManagement.Application;
using TodoTracker.WorkManagement.Infrastructure.Persistence;

namespace TodoTracker.WorkManagement.Infrastructure;

public static class ModuleRegistration
{
    public static IServiceCollection AddWorkManagementModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddApplication();
        
        return services;
    }
}