namespace BlazingPizza.UseCases;
internal sealed class GetOrdersInteractor : IGetOrdersInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;
    public GetOrdersInteractor(IBlazingPizzaQueriesRepository repository) => Repository = repository;

    public Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync() => Repository.GetOrdersAsync();
}
