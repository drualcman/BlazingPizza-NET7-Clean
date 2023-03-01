namespace BlazingPizza.ViewModels;
internal sealed class CheckoutViewModel : ICheckoutViewModel
{
    readonly ICheckoutModel Model;
    readonly IOrderStateService OrderStateService;

    public CheckoutViewModel(ICheckoutModel model, IOrderStateService orderStateService)
    {
        Model = model;
        OrderStateService = orderStateService;
    }

    public bool IsSubmitting {get; private set;}

    public Order Order => OrderStateService.Order;

    public Address Address { get; private set; } = new();

    public async Task<int> PalceOrderAsync() 
    {
        IsSubmitting= true;
        Order.SetDeliveryAddress(Address);
        int orderId = await Model.PlaceOrderAsync(Order);
        OrderStateService.ResetOrder();
        IsSubmitting= false;
        return orderId;
    }
}
