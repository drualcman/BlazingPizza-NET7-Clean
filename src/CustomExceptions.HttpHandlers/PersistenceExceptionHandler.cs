﻿namespace CustomExceptions.HttpHandlers;
internal sealed class PersistenceExceptionHandler : IHttpExceptionHandler<PersistenceException>
{
    public ProblemDetails Handle(PersistenceException exception) 
    {

        ProblemDetails problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Data cannot be saved.", 
            Detail = exception.InnerException == null ? exception.Message : exception.InnerException.Message,
            InvalidParams = null,
        };
        return problemDetails;
    }
}
