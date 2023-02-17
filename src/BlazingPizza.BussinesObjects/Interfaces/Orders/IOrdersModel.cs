namespace BlazingPizza.BussinesObjects.Interfaces.Orders;
public interface IOrdersModel
{
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync();
}
