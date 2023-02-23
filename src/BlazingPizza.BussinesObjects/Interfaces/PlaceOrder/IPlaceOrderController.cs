namespace BlazingPizza.Backend.BussinesObjects.Interfaces.PlaceOrder;
public interface IPlaceOrderController
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto order);
}
