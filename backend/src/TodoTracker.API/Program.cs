using Serilog;
using TodoTracker.API.Extensions;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Server starting up");
    
    var builder = WebApplication.CreateBuilder(args);
    
    builder.AddCore();

    var app = builder.Build();

    app.ConfigureCore();

    await app.RunAsync();
}
catch (Exception e)
{
    Log.Fatal(e, "Server terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}

public partial class Program
{
}