﻿using System.Net;

namespace TodoTracker.Shared.Domain.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string message) : base(message)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }
}