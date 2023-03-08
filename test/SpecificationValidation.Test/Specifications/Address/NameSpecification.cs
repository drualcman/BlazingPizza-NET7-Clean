namespace SpecificationValidation.Test.Specifications.Address;
internal class NameSpecification : Specification<ValueObjects.Address>
{
    public NameSpecification()
    {
        Property(a => a.Name)
            .AddRule(a => !string.IsNullOrWhiteSpace(a.Name), "Debe de proporcional el nombre");

        AddRule(nameof(ValueObjects.Address.Name), a => a.Name?.Length <= 50, "El nombre debe ser de maximo 50 caracteres")
            .AddRule(a => a.Name?.Length > 5, "El nombre debe ser de minimo 5 caracteres");
    }
}
