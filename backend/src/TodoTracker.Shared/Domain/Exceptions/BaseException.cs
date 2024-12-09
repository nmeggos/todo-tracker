using System.Net;

namespace TodoTracker.Shared.Domain.Exceptions;

public class BaseException : Exception
{
    protected BaseException(string message) : base(message)
    {
    }
    
    public HttpStatusCode StatusCode { get; protected set; }
}