namespace BlazingPizza.BussinesObjects.Interfaces.Common;
public interface IBlazingPizzaCommandsRepository
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto order);
}
