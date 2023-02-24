namespace BlazingPizza.UseCases;

internal sealed class GetSpecialsInteractor : IGetSpecialsInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetSpecialsInteractor(IBlazingPizzaQueriesRepository repository)
    {
        Repository = repository;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        IReadOnlyCollection<PizzaSpecial> result = await Repository.GetSpecialsAsync();
        return result.OrderByDescending(x => x.BasePrice).ToList();
    }
}