namespace BlazingPizza.ValidationWithSpecificationApi;
public class ValidationResult
{
    readonly List<ValidationError> ErrorsField = new();
    public bool IsValid => !ErrorsField.Any();
    public IEnumerable<ValidationError> Errors => ErrorsField;
    public void Add(ValidationError error) => ErrorsField.Add(error);
    public override string ToString() => string.Join(", ", ErrorsField.Select(e=> e.Message));
}
