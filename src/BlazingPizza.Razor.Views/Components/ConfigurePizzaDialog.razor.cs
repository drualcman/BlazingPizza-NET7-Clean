namespace BlazingPizza.Razor.Views.Components;
public partial class ConfigurePizzaDialog
{
    [Inject] public IConfigurePizzaDialogViewModel ViewModel { get; set; }
    [Parameter] public Pizza Pizza { get; set; }
    [Parameter] public EventCallback OnAdd { get; set; }
    [Parameter] public EventCallback OnCancel { get; set; }

    protected override async Task OnInitializedAsync() 
    {
        ViewModel.Pizza = Pizza;
        await ViewModel.GetToppingsAsync();
    }
}
