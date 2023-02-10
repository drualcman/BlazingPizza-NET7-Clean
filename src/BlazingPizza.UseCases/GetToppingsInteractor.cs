namespace BlazingPizza.UseCases;
public class GetToppingsInteractor : IGetToppingsInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetToppingsInteractor(IBlazingPizzaQueriesRepository repository) => Repository = repository;

    public Task<IReadOnlyCollection<Topping>> GetToppingAsync() => Repository.GetToppingsAsync();
}
