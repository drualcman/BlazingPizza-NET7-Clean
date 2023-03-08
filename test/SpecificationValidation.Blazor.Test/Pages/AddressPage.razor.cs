using System.Text;

namespace SpecificationValidation.Blazor.Test.Pages;

public partial class AddressPage
{
    [Inject] IValidator<Address> Validator { get; set; }

    Address Address = new();
    MarkupString StatusMessage;

    void Validate()
    {
        StringBuilder stringBuilder = new StringBuilder();
        ValidationResult result = Validator.Validate(Address);
        if(result.IsValid)
        {
            stringBuilder.Append("Datos validos!!!");
        }
        else
        {
            stringBuilder.Append(result.ToString());
        }
        stringBuilder.Append("<br/>");
        result = Validator.ValidateProperty(Address, nameof(Address.Postalcode));
        if(result.IsValid)
        {
            stringBuilder.Append("Codigo postal OK!!!");
        }
        else
        { 
            stringBuilder.Append(result.ToString());
        }
        StatusMessage = new MarkupString(stringBuilder.ToString());
    }

}