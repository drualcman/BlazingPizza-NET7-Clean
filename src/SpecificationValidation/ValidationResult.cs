namespace SpecificationValidation;
public class ValidationResult
{
    public bool IsValid => !ErrorsField.Any();
    public IEnumerable<ValidationError> Errors => ErrorsField;
    public override string ToString() => string.Join(" ", ErrorsField.Select(e=> e.Message));
    
    readonly List<ValidationError> ErrorsField = new List<ValidationError>();
    internal void AddRange(IEnumerable<ValidationError> errors) => ErrorsField.AddRange(errors);
}
