namespace BlazingPizza.FrondEnd.BussinesObjects.Interfaces.OrderDetails;
public interface IOrderDetailsModel
{
    Task<GetOrderDto> GetOrderAsync(int id);
}
