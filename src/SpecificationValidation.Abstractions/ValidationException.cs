namespace SpecificationValidation.Abstractions;
public class ValidationException : Exception
{

    public IEnumerable<IValidationError> Errors { get; }
    public ValidationException()
    {
    }

    public ValidationException(string message) : base(message)
    {
    }

    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ValidationException(IValidationResult validationResult) : base(validationResult.ToString())
    {
        Errors = validationResult.Errors;
    }
}
