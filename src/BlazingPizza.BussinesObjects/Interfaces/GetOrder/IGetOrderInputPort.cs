namespace BlazingPizza.BussinesObjects.Interfaces.GetOrder;
public interface IGetOrderInputPort
{
    Task<GetOrderDto> GetOrderAsync(int id);
}
