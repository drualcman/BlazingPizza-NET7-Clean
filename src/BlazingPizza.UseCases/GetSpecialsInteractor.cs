namespace BlazingPizza.UseCases;

internal class GetSpecialsInteractor : IGetSpecialsInputPort
{
    readonly IBlazingPizzaRepository Repository;

    public GetSpecialsInteractor(IBlazingPizzaRepository repository)
    {
        Repository = repository;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        IReadOnlyCollection<PizzaSpecial> result = await Repository.GetSpecialsAsync();
        return result.OrderByDescending(x => x.BasePrice).ToList();
    }
}