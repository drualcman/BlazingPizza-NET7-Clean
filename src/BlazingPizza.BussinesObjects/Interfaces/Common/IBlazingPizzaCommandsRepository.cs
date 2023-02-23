namespace BlazingPizza.Backend.BussinesObjects.Interfaces.Common;
public interface IBlazingPizzaCommandsRepository
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto order);
}
