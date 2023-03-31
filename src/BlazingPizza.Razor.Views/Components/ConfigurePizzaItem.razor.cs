using SweetAlert.Blazor;

namespace BlazingPizza.Razor.Views.Components;
public partial class ConfigurePizzaItem
{
    [Inject] public SweetAlertService SweetAlert { get; set; }
    [Parameter] public Pizza Pizza { get; set; }
    [Parameter] public EventCallback OnRemoved { get; set; }

    async Task RemovePizaConfirmation()
    {
        if(await SweetAlert.PopUpconfirm("Eliminar la pizza", $"{Pizza.Special.Name} de la order?", "Si, eliminar la pizza", "No, quiero dejarla en mi orden", "warning"))
            await OnRemoved.InvokeAsync();
    }
}
