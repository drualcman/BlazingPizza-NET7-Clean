namespace BlazingPizza.BussinesObjects.Interfaces.MyOrders;
public interface IMyOrdersViewModel
{
    IReadOnlyCollection<OrderWithStatusDto> OrdersWithStatus { get; }
    Task GetOrderAsync();
}
