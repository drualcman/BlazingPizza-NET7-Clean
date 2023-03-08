namespace SpecificationValidation.Test.Specifications.Address;
internal class RegionSpecification : Specification<ValueObjects.Address>
{
    public RegionSpecification()
    {
        Property(a => a.Region)
            .AddRule(a => !string.IsNullOrEmpty(a.Region), "La region tiene que tener al menos 3 caracteres")
            .AddRule(a => a.Region.Length >= 3, "La region tiene que tener al menos 3 caracteres")
            .AddRule(a => a.Region.Length < 20, "La region no puede ser mayor de 20 caracteres");
    }
}
