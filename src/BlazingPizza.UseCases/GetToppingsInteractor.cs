namespace BlazingPizza.UseCases;
public class GetToppingsInteractor : IGetToppingsInputPort
{
    readonly IBlazingPizzaRepository Repository;

    public GetToppingsInteractor(IBlazingPizzaRepository repository) => Repository = repository;

    public Task<IReadOnlyCollection<Topping>> GetToppingAsync() => Repository.GetToppingsAsync();
}
