namespace BlazingPizza.Razor.Views.Pages;
public partial class Index
{
    [Inject] IIndexViewModel ViewModel { get; set; }
    [Inject] IOrderStateService OrderStateService { get; set; }

    protected override void OnInitialized()
    {
        ViewModel.ShowingConfigureDialog = false;
    }
}
