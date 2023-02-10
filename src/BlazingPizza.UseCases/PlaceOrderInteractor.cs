namespace BlazingPizza.UseCases;
public class PlaceOrderInteractor : IPlaceOrderInputPort
{
    readonly IBlazingPizzaCommandsRepository Repository;

    public PlaceOrderInteractor(IBlazingPizzaCommandsRepository repository) => Repository = repository;

    public Task<int> PlaceOrderAsync(PlaceOrderOrderDto order) => Repository.PlaceOrderAsync(order);
}
