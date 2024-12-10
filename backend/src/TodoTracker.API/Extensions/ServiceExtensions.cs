using Asp.Versioning;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TodoTracker.API.Configurations;
using TodoTracker.Infrastructure;
using TodoTracker.Infrastructure.Persistence;
using TodoTracker.Shared.CQRS;
using TodoTracker.Shared.Infrastructure.Logging;

namespace TodoTracker.API.Extensions;

public static class ServiceExtensions
{
    public static WebApplicationBuilder AddCore(this WebApplicationBuilder builder)
    {
        builder.AddConfigurations();
        builder.AddLogging();
        builder.Services.AddHttpContextAccessor();
        
        builder.Services.AddWorkManagementModule(builder.Configuration);
        
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddApiVersioning(
                options =>
                {
                    // reporting api versions will return the headers
                    // "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                    options.DefaultApiVersion = new ApiVersion(1);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                })
            .AddApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

        return builder;
    }
}