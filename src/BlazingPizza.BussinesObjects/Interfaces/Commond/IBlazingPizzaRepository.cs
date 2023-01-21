namespace BlazingPizza.BussinesObjects.Interfaces.Commond;

public interface IBlazingPizzaRepository
{       
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
