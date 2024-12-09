using System.Net;

namespace TodoTracker.Shared.Domain.Exceptions;

public class MissingDependencyException : BaseException
{
    public MissingDependencyException(string message) : base(message)
    {
        StatusCode = HttpStatusCode.InternalServerError;
    }
}