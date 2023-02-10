namespace BlazingPizza.Razor.Views.Pages;
public partial class Checkout
{
    [Inject] public ICheckoutViewModel ViewModel { get; set; }
    [Inject] public NavigationManager NavigatinoManager { get; set; }

    async Task PlaceOrder()
    {
        int orderId = await ViewModel.PalceOrderAsync();
        NavigatinoManager.NavigateTo($"order/{orderId}");
    }
}
