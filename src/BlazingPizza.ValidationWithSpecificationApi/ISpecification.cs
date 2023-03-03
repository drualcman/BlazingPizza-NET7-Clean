namespace BlazingPizza.ValidationWithSpecificationApi;
public interface ISpecification<T>
{
    string ErrorMessage { get; }
    string PropertyName { get; }
    bool IsSatisfiedBy(T entity);
}
