namespace BussinesObjects.Test.Specifications.Address;
internal class AddressLine1Specification : ISpecification<ValueObjects.Address>
{
    public string ErrorMessage => "Debe especificar la direccion de envio";

    public string PropertyName => nameof(ValueObjects.Address.AddressLine1);

    public bool IsSatisfiedBy(ValueObjects.Address entity) => !string.IsNullOrWhiteSpace(entity.AddressLine1);
}
