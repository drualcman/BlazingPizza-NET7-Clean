namespace CustomExceptions.HttpHandlers;
internal class RefreshTokenCompromisedExceptionHandler: IHttpExceptionHandler<RefreshTokenCompromisedException>
{
    public ProblemDetails Handle(RefreshTokenCompromisedException exception)
    {
        ProblemDetails problemDetails = new()
        {                                                        
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,   
            Title = "Revoked Refresh Token"
        };
        return problemDetails;
    }
}
