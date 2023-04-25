namespace BlazingPizza.FrondEnd.BussinesObjects.Interfaces.Checkout;
public interface ICheckoutViewModel
{
    Address Address { get; }
    bool IsSubmitting { get; }
    Order Order { get; }
    Task<int> PalceOrderAsync();
    bool PlaceOrderSuccess { get; }
    Exception PlaceOrderException { get; }
}
