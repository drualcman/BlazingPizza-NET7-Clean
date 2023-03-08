namespace SpecificationValidation.Blazor.Test.Pages;

public partial class AddressPage
{
    [Inject] IValidator<Address> Validator { get; set; }

    Address Address = new();
    MarkupString StatusMessage;

    void Validate()
    {
        ValidationResult result = Validator.Validate(Address);
        if(result.IsValid)
        {
            StatusMessage = new MarkupString("Datos validos!!!");
        }
        else
        {
            StatusMessage = new MarkupString(result.ToString());
        }
    }

}