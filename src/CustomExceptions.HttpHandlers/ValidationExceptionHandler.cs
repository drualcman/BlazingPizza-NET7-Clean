namespace CustomExceptions.HttpHandlers;
internal sealed class ValidationExceptionHandler : IHttpExceptionHandler<ValidationException>
{
    public ProblemDetails Handle(ValidationException exception) 
    {
        var errors = exception.Errors.GroupBy(e => e.PropertyName);
        Dictionary<string, List<string>> errorlist = new();
        foreach (var error in errors)
        {
            errorlist.Add(error.Key, error.Select(e => e.Message).ToList());
        }

        ProblemDetails problemDetails = new()
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Error de validacion", 
            Detail = "Corrige los siguiente problemas:",
            InvalidParams = errorlist,
        };
        return problemDetails;
    }
}
