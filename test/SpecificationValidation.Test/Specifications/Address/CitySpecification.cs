namespace SpecificationValidation.Test.Specifications.Address;
internal class CitySpecification  : Specification<ValueObjects.Address>
{
    public CitySpecification()
    {
        Property(a => a.City)
            .AddRule(a => a.City?.Length > 3, "La ciudad debe ser de mas de 3 caracteres.");
    }
}
