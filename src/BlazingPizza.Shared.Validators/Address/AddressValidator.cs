namespace BlazingPizza.Shared.Validators.Address;
internal class AddressValidator : Validator<BussinesObjects.ValueObjects.Address>
{
    public AddressValidator(IEnumerable<ISpecification<BussinesObjects.ValueObjects.Address>> specifications) : base(specifications)
    {
    }
}
