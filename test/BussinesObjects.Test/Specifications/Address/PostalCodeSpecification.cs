namespace BussinesObjects.Test.Specifications.Address;
internal class PostalCodeSpecification : ISpecification<ValueObjects.Address>
{
    public string ErrorMessage => "Debe especificar un codigo postal";

    public string PropertyName => nameof(ValueObjects.Address.Postalcode);

    public bool IsSatisfiedBy(ValueObjects.Address entity) =>
        !string.IsNullOrWhiteSpace(entity.Postalcode) && 
        entity.Postalcode.Length <= 5;
}
