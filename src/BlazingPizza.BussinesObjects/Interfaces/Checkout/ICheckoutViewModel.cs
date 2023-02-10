namespace BlazingPizza.BussinesObjects.Interfaces.Checkout;
public interface ICheckoutViewModel
{
    bool IsSubmitting { get; }
    Order Order { get; }
    Task<int> PalceOrderAsync();
}
