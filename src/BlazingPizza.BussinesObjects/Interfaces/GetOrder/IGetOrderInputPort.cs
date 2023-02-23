namespace BlazingPizza.Backend.BussinesObjects.Interfaces.GetOrder;
public interface IGetOrderInputPort
{
    Task<GetOrderDto> GetOrderAsync(int id);
}
