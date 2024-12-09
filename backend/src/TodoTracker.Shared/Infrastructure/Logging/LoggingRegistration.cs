using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using Serilog.Extensions;

namespace TodoTracker.Shared.Infrastructure.Logging;

public static class LoggingRegistration
{
    public static IHostBuilder AddLogging(
        this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var environment = builder.Environment;
        
        builder.Host.UseSerilog((context, config) => config
            .WriteTo.Console()
            .WriteTo.Seq(configuration["Serilog:WriteTo:1:Args:serverUrl"])
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithCorrelationId()
            .Enrich.WithExceptionDetails()
            .Enrich.WithProperty("Application", "EventPlanner.API")
            .Enrich.WithProperty("Environment", environment.EnvironmentName));
        
        return builder.Host;
    }
}