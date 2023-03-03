namespace BlazingPizza.ValidationWithSpecificationApi;
public interface IValidator<T>
{
    ValidationResult Validate(T entity);
    ValidationResult ValidateProperty(T entity, string propertyName);
}
