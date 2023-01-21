namespace BlazingPizza.BussinesObjects.Interfaces.GetSpecials;

public interface IGetSpecialsController
{              
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
