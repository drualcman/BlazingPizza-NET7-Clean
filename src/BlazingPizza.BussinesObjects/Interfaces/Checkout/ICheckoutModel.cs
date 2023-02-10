namespace BlazingPizza.BussinesObjects.Interfaces.Checkout;
public interface ICheckoutModel
{
    Task<int> PlaceOrderAsync(Order order);
}
