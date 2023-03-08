namespace SpecificationValidation.Blazor.Test.Components;

public partial class AddressEditor
{
    [Parameter] public Address Address { get; set; }

    InputText NameField;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender)
            await NameField.Element.Value.FocusAsync();
    }
}