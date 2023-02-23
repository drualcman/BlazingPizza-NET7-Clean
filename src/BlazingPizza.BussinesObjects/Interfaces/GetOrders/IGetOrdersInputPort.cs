namespace BlazingPizza.Backend.BussinesObjects.Interfaces.GetOrders;
public interface IGetOrdersInputPort
{
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync();
}
