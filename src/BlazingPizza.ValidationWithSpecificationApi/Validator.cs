namespace BlazingPizza.ValidationWithSpecificationApi;
public abstract class Validator<T> : IValidator<T>
{
    readonly IEnumerable<ISpecification<T>> SpecificationsField;

    protected Validator(IEnumerable<ISpecification<T>> specificationsField) => SpecificationsField = specificationsField;

    public ValidationResult Validate(T entity) => Validate(SpecificationsField, entity);
    public ValidationResult ValidateProperty(T entity, string propertyName) => 
        Validate(SpecificationsField.Where(s=> s.PropertyName == propertyName), entity);

    ValidationResult Validate(IEnumerable<ISpecification<T>> specifications, T entity)
    {
        ValidationResult result = new();
        if(specifications is not null)
        {
            foreach(var specification in specifications)
            {
                if(!specification.IsSatisfiedBy(entity))
                {
                    result.Add(new ValidationError(specification.ErrorMessage, specification.PropertyName));
                }
            }
        }
        return result;
    }
}
