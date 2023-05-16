namespace CustomExceptions.HttpHandlers;
internal class RefreshTokenNotFoundExceptionHandler: IHttpExceptionHandler<RefreshTokenNotFoundException>
{
    public ProblemDetails Handle(RefreshTokenNotFoundException exception)
    {
        ProblemDetails problemDetails = new()
        {                                                        
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,   
            Title = "Invalid Refresh Token"
        };
        return problemDetails;
    }
}
