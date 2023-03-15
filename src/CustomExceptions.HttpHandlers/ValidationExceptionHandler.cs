namespace CustomExceptions.HttpHandlers;
internal sealed class ValidationExceptionHandler : IHttpExceptionHandler<ValidationException>
{
    public ProblemDetails Handle(ValidationException exception) 
    {
        var errors = exception.Errors.GroupBy(e => e.PropertyName);
        Dictionary<string, List<string>> errorlist = new Dictionary<string, List<string>>();
        foreach (var error in errors)
        {
            errorlist.Add(error.Key, error.Select(e => e.Message).ToList());
        }

        ProblemDetails problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Data validation error", 
            Detail = exception.Message,
            InvalidParams = errorlist,
        };
        return problemDetails;
    }
}
