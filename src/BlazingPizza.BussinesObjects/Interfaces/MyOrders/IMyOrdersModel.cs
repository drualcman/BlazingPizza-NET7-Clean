namespace BlazingPizza.BussinesObjects.Interfaces.MyOrders;
public interface IMyOrdersModel
{
    Task<IReadOnlyCollection<OrderWithStatusDto>> GetOrdersAsync();
}
