using BlazingPizza.Shared.BussinesObjects.ValueObjects;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazingPizza.Razor.Views.Components;

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