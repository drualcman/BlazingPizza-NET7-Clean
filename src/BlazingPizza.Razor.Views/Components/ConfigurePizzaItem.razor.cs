using SweetAlert.Blazor;

namespace BlazingPizza.Razor.Views.Components;
public partial class ConfigurePizzaItem
{
    [Inject] public SweetAlertService SweetAlert { get; set; }
    [Parameter] public Pizza Pizza { get; set; }
    [Parameter] public EventCallback OnRemoved { get; set; }

    async Task RemovePizaConfirmation()
    {
        if(await SweetAlert.ConfirmAsync(new ConfirmArgs("Eliminar la pizza",
            $"{Pizza.Special.Name} de la order?", Icon.Warning, 
            "Si, eliminar la pizza", "No, quiero dejarla en mi orden")))
            await OnRemoved.InvokeAsync();
    }
}
