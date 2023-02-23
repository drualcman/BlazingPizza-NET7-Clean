namespace BlazingPizza.FrondEnd.BussinesObjects.Interfaces.OrderDetails;
public interface IOrderDetailsViewModel
{
    GetOrderDto Order { get; }
    bool InvalidOrder { get; }
    Task GetOrderDetailsAsync(int id);
}
