using System.Diagnostics;
using System.Text.Json;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.Extensions.Logging;
using TodoTracker.Shared.Guards;

namespace TodoTracker.Shared.Infrastructure.Logging;

public class LoggingPipelineBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = Guard.Against.MissingDependency(logger, nameof(logger));
    }

    public async Task<TResponse> Handle(TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    
    {
        string requestName = typeof(TRequest).Name;

        if (_logger.IsEnabled(LogLevel.Information)) // Check if logging is enabled
        {
            var requestData = JsonSerializer.Serialize(request);
            _logger.LogInformation("Handling request {RequestName} with data: {@RequestData}", 
                requestName, requestData);
        }

        var stopwatch = Stopwatch.StartNew();

        try
        {
            TResponse response = await next();

            stopwatch.Stop();

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Handled request {RequestName} successfully in {ElapsedMilliseconds} ms", 
                    requestName, stopwatch.ElapsedMilliseconds);
            }

            return response;
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            _logger.LogError(ex, "Request {RequestName} failed after {ElapsedMilliseconds} ms with error: {ErrorMessage}", 
                requestName, stopwatch.ElapsedMilliseconds, ex.Message);
            throw;
        }
    }

}