using Serilog;
using TodoTracker.API.Infrastructure;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Server starting up");
    
    var builder = WebApplication.CreateBuilder(args);
    var environment = builder.Environment;
    var configuration = builder.Configuration;
    
    builder.AddCore();

    var app = builder.Build();

    app.ConfigureCore();

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

namespace TodoTracker.API
{
    public partial class Program
    {
    }
}