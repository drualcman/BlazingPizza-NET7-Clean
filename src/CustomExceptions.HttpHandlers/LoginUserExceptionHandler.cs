namespace CustomExceptions.HttpHandlers;
internal class LoginUserExceptionHandler : IHttpExceptionHandler<LoginUserException>
{
    public ProblemDetails Handle(LoginUserException exception)  =>
        new()
        {                                                        
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Las crediencials proporcionadas son incorrectas"
        };
}
