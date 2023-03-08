namespace SpecificationValidation.Test.Specifications.Address;
internal class AddressSpecification : Specification<ValueObjects.Address>
{
    public AddressSpecification()
    {
        Property(a => a.AddressLine1)
            .AddRule(a => !string.IsNullOrWhiteSpace(a.AddressLine1), "Debe especificar la direccion de envio.");

        AddRule(nameof(ValueObjects.Address.Postalcode), a => !string.IsNullOrWhiteSpace(a.Postalcode), "Debe proporcionar el codigo postal.")
            .AddRule(a => a.Postalcode.Length == 5, "El codigo postal debe de ser de 5 caracteres");
    }
}
