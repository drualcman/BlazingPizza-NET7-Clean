﻿namespace BlazingPizza.FrondEnd.BussinesObjects.Interfaces.Common;
public interface IOrderStateService
{
    Order Order { get; }
    void ResetOrder();
    void ReplaceOrder(Order order);
}
