namespace SpecificationValidation;
public interface ISpecification<T>
{
    IEnumerable<ValidationError> Errors { get; }
    bool IsSatisfiedBy(T entity);
    bool IsSatisfiedBy(T entity, string propertyName);
}
