namespace BlazingPizza.Razor.Views.Components;
public partial class OrderTrackerMap : IDisposable
{
    #region Servicios
    [Inject] IOrderStatusNotificator Notificator { get; set; }
    #endregion

    #region Partameters
    [Parameter] public byte ZoomLevel { get; set; } = 13;
    [Parameter] public GetOrderDto Order { get; set; }
    [Parameter] public EventCallback<OrderStatusNotification> OnNotification { get; set; }
    #endregion

    #region variables
    bool IsTracking;
    int DroneId;
    #endregion

    #region map
    Map Map;
    async Task OnCreateMapAsync(Map map)
    {
        Map = map;
        if(Order != null && !IsTracking)
        {
            await StartTracking(Order);
        }
    }
    #endregion

    #region overrides
    protected override async Task OnParametersSetAsync()
    {
        if(Map != null && !IsTracking)
        {
            await StartTracking(Order);
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender)
        {
            if(Map != null && !IsTracking)
            {
                await StartTracking(Order);
            }
        }
    }
    #endregion

    #region metodos
    async Task StartTracking(GetOrderDto order)
    {
        if(order != null)
        {
            IsTracking = true;
            DrMaps.Blazor.ValueObjects.LatLong destination = new DrMaps.Blazor.ValueObjects.LatLong(order.DeliveryLocation.Latitude, order.DeliveryLocation.Longitude);
            await Map.RemoveMarkersAsync();
            await Map.SetViewAsync(destination, ZoomLevel);
            LatLong origin = await Notificator.SubscribeAcync(Order, OnMove);
            DrMaps.Blazor.ValueObjects.LatLong home = new DrMaps.Blazor.ValueObjects.LatLong(origin.Latitude, origin.Longitude);
            await Map.AddMarkerAsync(home, "Origin", "Blazing Pizza Store");
            DroneId = await Map.AddMarkerAsync(home, "Dron", "Repartidor", DrMaps.Blazor.ValueObjects.Icon.DRON);
            await Map.AddMarkerAsync(destination, "Usted", "Lugar de entrega", DrMaps.Blazor.ValueObjects.Icon.DESTINATION);
        }
    }

    async void OnMove(OrderStatusNotification notification)
    {
        DrMaps.Blazor.ValueObjects.LatLong point = new 
            DrMaps.Blazor.ValueObjects.LatLong(notification.CurrentPosition.Latitude, 
                                               notification.CurrentPosition.Longitude);   
        await Map.MoveMarketAsync(DroneId, point);
        await OnNotification.InvokeAsync(notification);
        if(notification.Status == BlazingPizza.Shared.BussinesObjects.Enums.OrderStatus.Delivered)
        {
            IsTracking = false;
        }
    }

    public void Dispose()
    {
        Notificator.UnSubscripe(Order.Id);
    }
    #endregion
}
