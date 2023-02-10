namespace BlazingPizza.BussinesObjects.Interfaces.PlaceOrder;
public interface IPlaceOrderController
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto order);
}
