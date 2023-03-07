namespace BussinesObjects.Test.Validators;
internal class AddressValidator : Validator<Address>
{
    public AddressValidator(IEnumerable<ISpecification<Address>> specificationsField) : base(specificationsField)
    {
    }
}
