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
    int TrackingOrderId;
    #endregion

    #region map
    Map Map;
    async Task OnCreateMapAsync(Map map)
    {
        Map = map;
        await TryStartTracking(Order);
    }
    #endregion

    #region overrides
    protected override async Task OnParametersSetAsync()
    {
        await TryStartTracking(Order);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender)
        {
            await TryStartTracking(Order);
        }
    }
    #endregion

    #region metodos
    async Task TryStartTracking(GetOrderDto order)
    {
        if(Map != null && order != null)
        {
            if(!IsTracking)
            {
                await StartTracking(order);
            }
            else
            {
                if(order.Id != TrackingOrderId)
                {
                    Notificator.UnSubscribe(TrackingOrderId);
                    await StartTracking(order);
                }
            }
        }
    }

    async Task StartTracking(GetOrderDto order)
    {
        if(order != null)
        {
            IsTracking = true;
            TrackingOrderId = order.Id;
            DroneId = -1;
            await Map.RemoveMarkersAsync();
            await Map.SetViewAsync(FromLatLong(order.DeliveryLocation), ZoomLevel);
            LatLong origin = await Notificator.SubscribeAcync(Order, OnMove);
            await Map.AddMarkerAsync(FromLatLong(origin), "El restaurante", "Blazing Pizza Restaurant");
            await Map.AddMarkerAsync(FromLatLong(order.DeliveryLocation), "Usted", "Lugar de entrega", DrMaps.Blazor.ValueObjects.Icon.DESTINATION);
        }
    }

    DrMaps.Blazor.ValueObjects.LatLong FromLatLong(LatLong latLong) =>
        new DrMaps.Blazor.ValueObjects.LatLong(latLong.Latitude, latLong.Longitude);

    async void OnMove(OrderStatusNotification notification)
    {
        if(DroneId < 0)
        {
            DroneId = await Map.AddMarkerAsync(FromLatLong(notification.CurrentPosition), "Dron", "Repartidor", DrMaps.Blazor.ValueObjects.Icon.DRON);
        }
        else
        {
            await Map.MoveMarketAsync(DroneId, FromLatLong(notification.CurrentPosition));
        }
        await OnNotification.InvokeAsync(notification);
        if(notification.OrderStatus == BlazingPizza.Shared.BussinesObjects.Enums.OrderStatus.Delivered)
        {
            IsTracking = false;
        }
    }

    public void Dispose()
    {
        Notificator.UnSubscribe(Order.Id);
    }
    #endregion
}
