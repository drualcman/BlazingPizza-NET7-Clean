using BlazorDemo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorDemo.Pages;

public partial class TextDisplay
{
    [Parameter] public EventCallback<KeyTransfromation> OnKeyPressCallback { get; set; }

    string Data;

    async Task HandleKeyPress(KeyboardEventArgs e)
    {
        KeyTransfromation transfromation = new KeyTransfromation 
        {
            Key = e.Key
        };

        await OnKeyPressCallback.InvokeAsync(transfromation);

        Data += transfromation.TransformedKey;
    }
}