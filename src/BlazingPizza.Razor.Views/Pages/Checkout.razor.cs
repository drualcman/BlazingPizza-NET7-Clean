using WebPush.Blazor;

namespace BlazingPizza.Razor.Views.Pages;
public partial class Checkout
{
    [Inject] ICheckoutViewModel ViewModel { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    [Inject] IValidator<Address> AddressValidator { get; set; }
    [Inject] IToastService ToastService { get; set; }
    [Inject] WebPushService PushNotificationService { get; set; }

    void SetAddress(GeolocationAddress address)
    {
        ViewModel.Address.AddressLine1 = $"{address.AddressLine1} {address.AddressLine2}".Trim();
        ViewModel.Address.AddressLine2 = address.Street;
        ViewModel.Address.City = address.City;
        ViewModel.Address.Region = address.State;
        ViewModel.Address.Postalcode = address.PostalCode;
        ViewModel.Order.SetDeliveryLocation(new LatLong(address.Latitude, address.Longitude));
    }

    async Task PlaceOrder()
    {
        PushSubscrition subscription = await PushNotificationService.GetSubscriptionAsync();
        if (subscription != null)
        {
            ViewModel.Order.SetSubscription(new WebPushSubscrition(subscription.Endpoint, subscription.P256dh, subscription.Auth));
        }

        int orderId = await ViewModel.PlaceOrderAsync();
        if(ViewModel.PlaceOrderSuccess)
        {
            ToastService.ShowSuccess("Gracias!", "Tu pedido ha sido registrado.");
            NavigationManager.NavigateTo($"order/{orderId}");
        }
        else
            ToastService.ShowError(ViewModel.PlaceOrderException.Message, ExceptionMarkupBuilder.Build(ViewModel.PlaceOrderException), 0);
    }
}
