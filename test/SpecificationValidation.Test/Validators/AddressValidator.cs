namespace SpecificationValidation.Test.Validators;
internal class AddressValidator : Validator<Address>
{
    public AddressValidator(IEnumerable<ISpecification<Address>> specifications) : base(specifications)
    {
    }
}
