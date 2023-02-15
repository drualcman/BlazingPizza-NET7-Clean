namespace BlazingPizza.BussinesObjects.Interfaces.GetOrders;
public interface IGetOrdersController
{
    Task<IReadOnlyCollection<OrderWithStatusDto>> GetOrdersAsync();
}
