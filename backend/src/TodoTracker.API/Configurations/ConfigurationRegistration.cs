namespace TodoTracker.API.Configurations;

public static class ConfigurationRegistration
{
    public static WebApplicationBuilder AddConfigurations(this WebApplicationBuilder builder)
    {
        const string configDirectory = "Configurations";
        
        var environment = builder.Environment;

        builder.Configuration
            .AddJsonFile($"{configDirectory}/appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"{configDirectory}/appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"{configDirectory}/logging.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"{configDirectory}/logging.{environment}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        builder.Services.AddOptions();
        
        return builder;
    }
}