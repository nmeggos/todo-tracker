using Microsoft.EntityFrameworkCore;
using Serilog;
using TodoTracker.Infrastructure.Persistence;

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

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
}