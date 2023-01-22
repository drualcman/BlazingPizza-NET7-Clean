namespace BlazingPizza.BussinesObjects.Interfaces.Commond;
public interface IBlazingPizzaWebApiGateway
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
