namespace SpecificationValidation;
public class ValidationError
{
    public string Message { get; }
    public string PropertyName { get; }

    internal ValidationError(string message, string propertyName)
    {
        Message = message;
        PropertyName = propertyName;
    }
}
