﻿namespace BlazingPizza.Shared.BussinesObjects.Interfaces;
public interface IOrderStatusNotificator
{
    Task<LatLong> SubscribeAcync(GetOrderDto order, Action<OrderStatusNotification> callBack);
    void UnSubscripe(int orderId);

}
