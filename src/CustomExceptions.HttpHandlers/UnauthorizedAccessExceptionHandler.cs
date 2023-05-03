namespace CustomExceptions.HttpHandlers;
internal class UnauthorizedAccessExceptionHandler : IHttpExceptionHandler<UnauthorizedAccessException>
{    
    public ProblemDetails Handle(UnauthorizedAccessException exception) 
    {

        ProblemDetails problemDetails = new()
        {
            Status = StatusCodes.Status401Unauthorized,
            Type = StatusCodes.Status401UnauthorizedType,
            Title = "Acceso no autorizado.", 
            Detail = "El recurso solicitado no fue autorizado.",
            InvalidParams = null,
        };
        return problemDetails;
    }
}
