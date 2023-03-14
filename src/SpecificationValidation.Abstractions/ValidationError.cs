namespace SpecificationValidation.Abstractions;
public class ValidationError : IValidationError
{
    public string Message { get; }
    public string PropertyName { get; }

    internal ValidationError(string message, string propertyName)
    {
        Message = message;
        PropertyName = propertyName;
    }
}
