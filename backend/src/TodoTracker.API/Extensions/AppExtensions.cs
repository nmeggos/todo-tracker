using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TodoTracker.Infrastructure.Persistence;
using TodoTracker.Shared.Endpoints;

namespace TodoTracker.API.Extensions;

public static class AppExtensions
{
    public static WebApplication? ConfigureCore(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        
        app.Lifetime.ApplicationStarted.Register(() =>
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<TodoTrackerDbContext>();
            dbContext.Database.Migrate();
        });

        app.MapModuleEndpoints();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
    
    internal static WebApplication MapModuleEndpoints(this WebApplication app)
    {
        var versionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .HasApiVersion(new ApiVersion(2))
            .ReportApiVersions()
            .Build();
        
        var group = app.MapGroup("v{version:apiVersion}")
            .WithApiVersionSet(versionSet);
        
        group.MapEndpoints();
        group.MapControllers();
        
        return app;
    }
}