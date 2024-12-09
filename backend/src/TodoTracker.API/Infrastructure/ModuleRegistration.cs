using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TodoTracker.API.Configurations;
using TodoTracker.Infrastructure;
using TodoTracker.Infrastructure.Persistence;
using TodoTracker.Shared.CQRS;
using TodoTracker.Shared.Infrastructure.Logging;

namespace TodoTracker.API.Infrastructure;

public static class ModuleRegistration
{
    public static WebApplicationBuilder AddCore(this WebApplicationBuilder builder)
    {
        builder.AddConfigurations();
        builder.AddLogging();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddControllers();
        
        builder.Services.AddWorkManagementModule(builder.Configuration);
        
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        return builder;
    }
    
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