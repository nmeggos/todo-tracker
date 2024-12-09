namespace TodoTracker.Shared.Infrastructure.Persistence.Settings;

public class DatabaseSettingsSetup : IConfigureOptions<DatabaseSettings>
{
    private readonly IConfiguration _configuration;

    public DatabaseSettingsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseSettings settings)
    {
        _configuration.GetSection("DatabaseSettings").Bind(settings);
    }
}
