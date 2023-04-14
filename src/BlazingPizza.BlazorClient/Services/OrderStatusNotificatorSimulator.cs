namespace BlazingPizza.BlazorClient.Services;

public class OrderStatusNotificatorSimulator : IOrderStatusNotificator, IDisposable
{
    readonly Dictionary<int, TrackedOrder> TrackedOrders = new();

    public Task<LatLong> SubscribeAcync(GetOrderDto order, Action<OrderStatusNotification> callBack)
    {
        TrackedOrder trackedOrder = GetOrderDataFake(order, callBack);
        TrackedOrders.TryAdd(order.Id, trackedOrder);
        ComputePosition(order.Id);
        return Task.FromResult(trackedOrder.Origin);
    }

    TrackedOrder GetOrderDataFake(GetOrderDto order, Action<OrderStatusNotification> callBack)
    {
        double speedKmXHr = 100;
        double deliveryTimeInMinutes = 1.5;
        double distanceInMetter = (speedKmXHr * (deliveryTimeInMinutes) / 60) * 1000.0;
        double degree = new Random().Next(0, 360);
        DrMaps.Blazor.ValueObjects.LatLong mapOrigin = new DrMaps.Blazor.ValueObjects.LatLong(order.DeliveryLocation.Latitude, order.DeliveryLocation.Longitude);
        mapOrigin = mapOrigin.AddKm(degree, -2.5);
        LatLong origin = new LatLong() { Latitude = mapOrigin.Latitude, Longitude = mapOrigin.Longitude };
        System.Timers.Timer timer = new System.Timers.Timer(250);
        timer.Elapsed += (sender, e) => ComputePosition(order.Id);
        timer.Start();
        return new TrackedOrder(origin, order.DeliveryLocation, order.CreatedTime, callBack,
            speedKmXHr, distanceInMetter, degree, timer);
    }

    private void ComputePosition(int orderId)
    {
        TrackedOrder trackedOrder = TrackedOrders[orderId];
        OrderStatus status;
        LatLong currentPosition = trackedOrder.Origin;
        double distance = 0;

        TimeSpan PreparationDurationTime = TimeSpan.FromSeconds(10);
        TimeSpan DeliveryDurationTime = TimeSpan.FromMinutes(1.5);
        DateTime dispathTime = trackedOrder.CreatedTime.Add(PreparationDurationTime);

        if(DateTime.Now < dispathTime) status = OrderStatus.Preparing;
        else if(DateTime.Now < dispathTime + DeliveryDurationTime)
        {
            status = OrderStatus.OutForDelivery;
            if(trackedOrder.StartForDelivery == default)
            {    
                double elapsetSecondsFromDispatchTime = DateTime.Now.Subtract(dispathTime).TotalSeconds;
                trackedOrder.StartForDelivery = DateTime.Now.AddSeconds(-elapsetSecondsFromDispatchTime);
            }
            double elapsetTimeHours = (DateTime.Now - trackedOrder.StartForDelivery).TotalSeconds / 3600;
            distance = (trackedOrder.Speed * elapsetTimeHours) * 1000.0;
            if(distance >= trackedOrder.TotalDistance)
            {
                distance = trackedOrder.TotalDistance;
                status = OrderStatus.Delivered;
            }
            DrMaps.Blazor.ValueObjects.LatLong mapOrigin = new DrMaps.Blazor.ValueObjects.LatLong(trackedOrder.Destination.Latitude, trackedOrder.Destination.Longitude);
            mapOrigin = mapOrigin.AddMetters(trackedOrder.Degree, distance);
            currentPosition = new LatLong() { Latitude = mapOrigin.Latitude, Longitude = mapOrigin.Longitude };         
        }
        else
        {
            currentPosition = trackedOrder.Destination;
            distance = trackedOrder.TotalDistance;
            status = OrderStatus.Delivered;
        }

        OrderStatusNotification notification = new OrderStatusNotification(currentPosition, distance, status);
        trackedOrder.Callback(notification);
        if(status == OrderStatus.Delivered)
        {
            UnSubscripe(orderId);
        }
    }

    public void UnSubscripe(int orderId)
    {
        if(TrackedOrders.ContainsKey(orderId))
        {
            TrackedOrder trackedOrder = TrackedOrders[orderId];
            trackedOrder.Timer.Dispose();
            TrackedOrders.Remove(orderId);
        }
    }

    public void Dispose()
    {
        foreach(var item in TrackedOrders)
        {
            item.Value.Timer.Dispose();
        }
        TrackedOrders.Clear();
    }
}
