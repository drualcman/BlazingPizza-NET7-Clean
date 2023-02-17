namespace BlazingPizza.BussinesObjects.Interfaces.Orders;
public interface IOrdersViewModel
{
    IReadOnlyCollection<GetOrdersDto> OrdersWithStatus { get; }
    Task GetOrderAsync();
}
