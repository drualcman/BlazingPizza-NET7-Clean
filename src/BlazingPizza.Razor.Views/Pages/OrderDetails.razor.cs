namespace BlazingPizza.Razor.Views.Pages;
      
[Authorize]
public partial class OrderDetails
{
    [Inject] IOrderDetailsViewModel ViewModel { get; set; }
    [Parameter] public int OrderId { get; set; }

    OrderStatus OrderStatus;
    protected override async Task OnParametersSetAsync()
    {
        await ViewModel.GetOrderDetailsAsync(OrderId);
        OrderStatus = ViewModel.Order.Status;
    }

    void Notification(OrderStatusNotification notification)
    {
        OrderStatus = notification.OrderStatus;
    }
}