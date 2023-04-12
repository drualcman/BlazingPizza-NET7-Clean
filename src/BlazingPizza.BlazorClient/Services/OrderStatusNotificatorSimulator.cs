namespace BlazingPizza.BlazorClient.Services;

public class OrderStatusNotificatorSimulator : IOrderStatusNotificator
{
    List<GetOrderDto> Subscriptions = new();

    public Task<LatLong> SubscribeAcync(GetOrderDto order, Action<OrderStatusNotification> callBack)
    {
        Subscriptions.Add(order);
        throw new NotImplementedException();
    }

    public void UnSubscripe(int orderId)
    {
        throw new NotImplementedException();
    }
}
