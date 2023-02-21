namespace BlazingPizza.BussinesObjects.Interfaces.OrderDetails;
public interface IOrderDetailsModel
{
    Task<GetOrderDto> GetOrderAsync(int id);
}
