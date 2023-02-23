namespace BlazingPizza.Backend.BussinesObjects.Interfaces.GetSpecials;

public interface IGetSpecialsController
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
