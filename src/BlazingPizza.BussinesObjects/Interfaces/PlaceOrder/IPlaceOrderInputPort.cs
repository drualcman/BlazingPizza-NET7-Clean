namespace BlazingPizza.Backend.BussinesObjects.Interfaces.PlaceOrder;
public interface IPlaceOrderInputPort
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto order);
}
