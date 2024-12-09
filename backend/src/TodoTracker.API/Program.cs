
using Serilog;
using TodoTracker.API.Configurations;
using TodoTracker.Shared.Infrastructure.Logging;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Server starting up");
    
    var builder = WebApplication.CreateBuilder(args);
    var environment = builder.Environment;
    var configuration = builder.Configuration;
    
    builder.AddConfigurations();
    builder.AddLogging();

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    app.MapGet("/", () =>
    {
        Log.Information("Hello World endpoint hit");
        return "Hello World!";
    });

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Server terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program
{
}