using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TodoTracker.Shared.Infrastructure.Persistence.Settings;
using TodoTracker.Domain;
using TodoTracker.Domain.WorkManagement;
using TodoTracker.Infrastructure.Persistence.Repositories;

namespace TodoTracker.Infrastructure.Persistence;

public static class PersistenceRegistration
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.ConfigureOptions<DatabaseSettingsSetup>();
        
        services.AddDbContext<TodoTrackerDbContext>((serviceProvider, options) =>
        {
            var datastoreSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            options.UseNpgsql(datastoreSettings.ConnectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IWorkItemRepository, WorkItemRepository>();

        return services;
    }
}