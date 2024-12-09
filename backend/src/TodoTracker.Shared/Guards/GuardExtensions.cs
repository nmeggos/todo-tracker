using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using TodoTracker.Shared.Domain.Exceptions;

namespace TodoTracker.Shared.Guards;

public static class GuardExtensions
{
    public static string InvalidEmail(this IGuardClause guardClause, string value)
    {
        var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        
        if (!emailRegex.IsMatch(value))
        {
            throw new BadRequestException($"The email address '{value}' is invalid.");
        }

        return value;
    }
    
    public static T Null<T>(this IGuardClause guardClause, T value, Exception exception) where T : class
    {
        if (value is null)
        {
            throw exception;
        }

        return value;
    }
    
    public static T NotFound<T>(this IGuardClause guardClause, T value, Exception exception) where T : class
    {
        if (value is null)
        {
            throw exception;
        }

        return value;
    }
    
    public static T MissingDependency<T>(this IGuardClause guardClause, T value, string dependencyName) where T : class
    {
        if (value is null)
        {
            throw new MissingDependencyException($"Missing dependency: {dependencyName}");
        }

        return value;
    }
}