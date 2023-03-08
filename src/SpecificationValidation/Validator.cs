namespace SpecificationValidation;
public abstract class Validator<T> : IValidator<T>
{
    readonly IEnumerable<ISpecification<T>> Specifications;

    protected Validator(IEnumerable<ISpecification<T>> specifications) => Specifications = specifications;

    ValidationResult ValidateHelper(T entity, string propernyName = null)
    {
        ValidationResult validationResult = new();
        foreach (ISpecification<T> specification in Specifications)
        {
            bool isSatisfied = propernyName == null ? specification.IsSatisfiedBy(entity) : specification.IsSatisfiedBy(entity, propernyName);
            if (!isSatisfied) 
            {
                validationResult.AddRange(specification.Errors);
            }
        }
        return validationResult;
    }

    public ValidationResult Validate(T entity) => ValidateHelper(entity);
    public ValidationResult ValidateProperty(T entity, string propertyName) => ValidateHelper(entity, propertyName);
}
