namespace BlazingPizza.Razor.Views.Pages;
public partial class Checkout
{
    [Inject] public ICheckoutViewModel ViewModel { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    async Task PlaceOrder()
    {
        int orderId = await ViewModel.PalceOrderAsync();
        NavigationManager.NavigateTo("orders");
    }
}
