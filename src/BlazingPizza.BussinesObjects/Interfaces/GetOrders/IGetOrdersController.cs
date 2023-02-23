namespace BlazingPizza.Backend.BussinesObjects.Interfaces.GetOrders;
public interface IGetOrdersController
{
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync();
}
