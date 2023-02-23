namespace BlazingPizza.FrondEnd.BussinesObjects.Interfaces.Orders;
public interface IOrdersViewModel
{
    IReadOnlyCollection<GetOrdersDto> Orders { get; }
    Task GetOrderAsync();
}
