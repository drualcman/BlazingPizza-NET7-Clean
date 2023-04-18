using DrMaps.Blazor.Entities;
using ExceptionHandler.Razor;
using Geolocation.Blazor;
using Toast.Blazor;

namespace BlazingPizza.Razor.Views.Pages;
public partial class Checkout
{
    [Inject] public ICheckoutViewModel ViewModel { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IValidator<Address> AddressValidator { get; set; }     
    [Inject] public IToastService ToastService { get; set; }
    [Inject] public GeolocationService GeolocationService { get; set; }

    Map Map;
    void OnCreateMapAsync(Map map)
    {
        Map = map;
    }

    async Task ShowLocation()
    {
        var position = await GeolocationService.GetPositionAsync();
        if(!position.Equals(default(LatLongPosition)))
        {
            var mapPosition = new DrMaps.Blazor.ValueObjects.LatLong(position.Latitude, position.Longitude);
            await Map.SetViewAsync(mapPosition, 19);
            await Map.AddDraggableMarkerAsync(mapPosition, "Mi casa", $"{position.Latitude}, {position.Longitude}", DrMaps.Blazor.ValueObjects.Icon.DESTINATION);
        }
    }
    void OnDragend(DraggedEventArgs point)
    {
        Console.WriteLine(point.MarkerId);
        Console.WriteLine(point.Point);
    }

    async Task PlaceOrder()
    {
        int orderId = await ViewModel.PalceOrderAsync();
        if(ViewModel.PlaceOrderSuccess)
        {
            ToastService.ShowSuccess("Gracias!", "Tu pedido ha sido registrado.");
            NavigationManager.NavigateTo($"order/{orderId}"); 
        }
        else
            ToastService.ShowError(ViewModel.PlaceOrderException.Message, ExceptionMarkupBuilder.Build(ViewModel.PlaceOrderException), 0);
    }
}
