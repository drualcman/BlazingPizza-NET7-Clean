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

    public bool PlaceOrderSuccess => PlaceOrderException == null;
    public Exception PlaceOrderException { get; private set; }

    public bool IsSubmitting { get; private set; }

    public Order Order => OrderStateService.Order;

    public Address Address { get; private set; } = new();

    public async Task<int> PlaceOrderAsync()
    {
        int orderId = 0;
        IsSubmitting = true;
        Order.SetDeliveryAddress(Address);
        try
        {
            orderId = await Model.PlaceOrderAsync(Order);
            OrderStateService.ResetOrder();
            Address = new();
        }
        catch(Exception ex)
        {
            PlaceOrderException = ex;
        }
        finally
        {
            IsSubmitting = false;
        }
        return orderId;
    }

}
