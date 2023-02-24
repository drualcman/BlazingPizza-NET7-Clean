namespace BlazingPizza.UseCases;
internal sealed class GetOrderInteractor : IGetOrderInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetOrderInteractor(IBlazingPizzaQueriesRepository repository) => Repository = repository;

    public Task<GetOrderDto> GetOrderAsync(int id) => Repository.GetOrderAsync(id);
}
