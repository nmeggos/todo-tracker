using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TodoTracker.Shared.Infrastructure.Persistence.Settings;
using TodoTracker.workManagement.Domain;
using TodoTracker.WorkManagement.Infrastructure.Persistence.Repositories;

namespace TodoTracker.WorkManagement.Infrastructure.Persistence;

public static class PersistenceRegistration
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<WorkManagementDbContext>((serviceProvider, options) =>
        {
            var datastoreSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            options.UseSqlServer(datastoreSettings.ConnectionString);
        });

        services.AddScoped<IWorkItemRepository, WorkItemRepository>();

        return services;
    }
}