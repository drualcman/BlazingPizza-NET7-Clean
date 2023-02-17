namespace BlazingPizza.BussinesObjects.Interfaces.GetOrder;
public interface IGetOrderController
{
    Task<GetOrderDto> GetOrderAsync(int id);
}
