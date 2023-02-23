namespace BlazingPizza.FrondEnd.BussinesObjects.Interfaces.Checkout;
public interface ICheckoutModel
{
    Task<int> PlaceOrderAsync(Order order);
}
