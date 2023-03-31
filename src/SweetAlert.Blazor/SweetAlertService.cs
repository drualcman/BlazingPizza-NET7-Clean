using Microsoft.JSInterop;

namespace SweetAlert.Blazor;
public class SweetAlertService
{
    readonly Lazy<Task<IJSObjectReference>> JSObjectReference;

    public SweetAlertService(IJSRuntime jsRuntime)
    {
        JSObjectReference = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/SweetAlert.Blazor/sweetalert.min.js").AsTask());
    }

    public async Task<bool> PopUpconfirm(string title, string message, string confim, string abort, string icon)
    {     
        IJSObjectReference module = await JSObjectReference.Value;
        var MessageParameters = new
        {
            title = title,
            text = message,
            icon = icon,
            buttons = new 
            {
                abort = new
                {
                    text = abort,
                    value = false
                },
                confirm = new
                {
                    text = confim,
                    value = true
                }
            },
            dangerMode = true
        };
        bool remove = false;
        try
        {
            remove = await module.InvokeAsync<bool>("swalpop", MessageParameters);
        }
        catch { }
        return remove;
    }
}
