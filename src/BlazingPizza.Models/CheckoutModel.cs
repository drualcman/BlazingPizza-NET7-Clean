namespace BlazingPizza.Models;
public class CheckoutModel : ICheckoutModel
{
    public Task<int> PlaceOrderAsync(Order order)
    {
        return Task.FromResult(0);
    }
}
