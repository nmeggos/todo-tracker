using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TodoTracker.Shared.CQRS.Commands;
using TodoTracker.Shared.CQRS.Queries;

namespace TodoTracker.Shared.CQRS;

public static class CqrsRegistrationExtensions
{
    public static IServiceCollection AddCqrs(
        this IServiceCollection services,
        Action<IServiceCollection>? decorators = null,
        params Assembly[] assemblies)
    {
       var assembliesToScan = assemblies.Any() ? assemblies : new[] { Assembly.GetExecutingAssembly() };

       services.AddMediatR(configure => configure.RegisterServicesFromAssemblies(assembliesToScan));

       services.AddTransient<ICommandExecutor, CommandExecutor>();
       services.AddTransient<IQueryExecutor, QueryExecutor>();
       
       services.AddTransient<IRequestExecutor, RequestExecutor>();
        
       decorators?.Invoke(services);

       return services;
    }
}