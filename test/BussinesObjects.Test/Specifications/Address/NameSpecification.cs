namespace BussinesObjects.Test.Specifications.Address;
internal class NameSpecification : ISpecification<ValueObjects.Address>
{
    public string ErrorMessage => "Debe especificar el nombre";

    public string PropertyName => nameof(ValueObjects.Address.Name);

    public bool IsSatisfiedBy(ValueObjects.Address entity) => !string.IsNullOrWhiteSpace(entity.Name);
}
