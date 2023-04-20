namespace BlazingPizza.Razor.Views.Components;
public partial class GeolocationMap
{
    [Inject] public IGeocoder GeoCoder { get; set; }
    [Inject] public GeolocationService GeolocationService { get; set; }

    [Parameter] public EventCallback<GeolocationAddress> OnSetPosition { get; set; }

    int MarketId;
    Map Map;
    async Task OnCreateMapAsync(Map map)
    {
        Map = map;
        await ShowLocation();
    }

    async Task ShowLocation()
    {
        LatLongPosition position = await GeolocationService.GetPositionAsync();
        if(!position.Equals(default(LatLongPosition)))
        {
            DrMaps.Blazor.ValueObjects.LatLong mapPosition = new DrMaps.Blazor.ValueObjects.LatLong(position.Latitude, position.Longitude);
            await Map.SetViewAsync(mapPosition, 19);
            MarketId = await Map.AddDraggableMarkerAsync(mapPosition, "Mi casa", $"{position.Latitude}, {position.Longitude}", DrMaps.Blazor.ValueObjects.Icon.DESTINATION);
            await UpdateAddress(position.Latitude, position.Longitude);
        }
        else
        {
            Console.WriteLine("GeolocationMap: No se pudo optener la ubicacion");
        }
    }

    async Task UpdateAddress(double latitude, double longitude)
    {
        GeolocationAddress address = await GeoCoder.GetGeocodingAddressAsync(latitude, longitude);
        string message = $"{address.Formatted}<br/>Latitude: {latitude}, {longitude}";
        await Map.SetPopupMarkerContent(MarketId, message);
        if(OnSetPosition.HasDelegate)
            await OnSetPosition.InvokeAsync(address);
    }

    async void OnDragend(DragendMarkerEventArgs point)
    {
        await UpdateAddress(point.Point.Latitude, point.Point.Longitude);
    }

}
