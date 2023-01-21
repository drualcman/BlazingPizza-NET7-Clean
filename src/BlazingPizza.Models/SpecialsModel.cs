namespace BlazingPizza.Models;

public class SpecialsModel : ISpecialsModel
{
    readonly IBlazingPizzaRepository Repository;

    public SpecialsModel(IBlazingPizzaRepository repository)
    {
        Repository = repository;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        return await Repository.GetSpecialsAsync(); 
    }
}