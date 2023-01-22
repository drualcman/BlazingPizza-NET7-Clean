namespace BlazingPizza.Models;

public class SpecialsModel : ISpecialsModel
{
    readonly IBlazingPizzaWebApiGateway Gateway;

    public SpecialsModel(IBlazingPizzaWebApiGateway gateway) => Gateway = gateway;

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        return await Gateway.GetSpecialsAsync(); 
    }
}