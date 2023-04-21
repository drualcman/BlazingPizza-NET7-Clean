namespace BlazingPizza.OrderTrackerSimulator.Services;

internal class OrderStatusNotificatorSimulator : IOrderStatusNotificator, IDisposable
{
    #region Constantes
    const int PreparationTime = 10;
    const double SpeedKmHr = 100.0;
    const double DistanceKm = 2.5;
    const double NotificationIntervalInSeconds = 2.5;
    #endregion

    readonly GoToDestinationSimulator Simulator = new();
    readonly Dictionary<int, Action<OrderStatusNotification>> TrackedOrders = new();

    public async Task<LatLong> SubscribeAcync(GetOrderDto order, Action<OrderStatusNotification> callBack)
    {
        TrackedOrders.TryAdd(order.Id, callBack);
        RouteInfo routeInfo = new RouteInfo(order.Id,
            new PositionTrackerSimulator.ValueObjects.PositionTrackerLatLong(order.DeliveryLocation.Latitude, order.DeliveryLocation.Longitude),
            order.CreatedTime.AddSeconds(PreparationTime), SpeedKmHr, DistanceKm, NotificationIntervalInSeconds, OnChangePosition);
        PositionTrackerSimulator.ValueObjects.PositionTrackerLatLong origin = await Simulator.SubscribeAcync(routeInfo);
        return new LatLong(origin.Latitude, origin.Longitude);

    }

    private void OnChangePosition(PositionNotification notification)
    {
        TrackedOrders[notification.RouteId].Invoke(new 
            OrderStatusNotification(new LatLong(notification.CurrentPosition.Latitude, notification.CurrentPosition.Longitude),
                notification.CurrentDistanceInMetters,
                notification.CurrentDistanceInMetters == 0 ? OrderStatus.Preparing : notification.Finished ? OrderStatus.Delivered : OrderStatus.OutForDelivery
            ));
    }

    public void UnSubscribe(int orderId)
    {
        if(TrackedOrders.ContainsKey(orderId))
        {
            Simulator.UnSubscribe(orderId);
            TrackedOrders.Remove(orderId);
        }
    }

    public void Dispose()
    {
        foreach(var order in TrackedOrders)
        {
            UnSubscribe(order.Key);
        }
        TrackedOrders.Clear();
    }
}
