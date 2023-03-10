namespace BlazingPizza.Shared.Validators.Address;
internal class AddressSpecification : Specification<BussinesObjects.ValueObjects.Address>
{
    public AddressSpecification()
    {
        Property(a => a.Name)
            .AddRule(a => !string.IsNullOrWhiteSpace(a.Name), "Debe especificar el nombre");
        Property(a => a.AddressLine1)
            .AddRule(a => !string.IsNullOrWhiteSpace(a.Name), "Debe especificar la direccion");
        Property(a => a.Postalcode)
            .AddRule(a => !string.IsNullOrWhiteSpace(a.Name), "Debe especificar el codigo postal")
            .AddRule(a => a.Postalcode.Length == 5, "El codigo postal debe ser de 5 caracteres");
    }
}
