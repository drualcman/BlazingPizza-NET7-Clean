namespace BlazingPizza.BussinesObjects.Interfaces.PlaceOrder;
public interface IPlaceOrderInputPort
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto order);
}
