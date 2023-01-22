namespace BlazingPizza.Models;

public class SpecialsModel : ISpecialsModel
{

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        return await Task.FromResult(new List<PizzaSpecial>()); 
    }
}