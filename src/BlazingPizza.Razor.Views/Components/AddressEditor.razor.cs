namespace BlazingPizza.Razor.Views.Components;

public partial class AddressEditor
{
    [Parameter] public Address Address { get; set; }

    ElementReference NameField;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await NameField.FocusAsync();
    }
}