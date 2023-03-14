namespace BlazingPizza.Razor.Views.Pages;
public partial class Checkout
{
    [Inject] public ICheckoutViewModel ViewModel { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IValidator<Address> AddressValidator { get; set; }

    async Task PlaceOrder()
    {
        int orderId = await ViewModel.PalceOrderAsync();
        if (orderId > 0) 
            NavigationManager.NavigateTo($"order/{orderId}");
    }
}
