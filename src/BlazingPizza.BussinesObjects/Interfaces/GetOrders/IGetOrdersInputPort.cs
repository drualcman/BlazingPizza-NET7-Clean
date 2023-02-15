﻿namespace BlazingPizza.BussinesObjects.Interfaces.GetOrders;
public interface IGetOrdersInputPort
{
    Task<IReadOnlyCollection<OrderWithStatusDto>> GetOrdersAsync();
}
