namespace BlazingPizza.Backend.BussinesObjects.Interfaces.GetSpecials;

public interface IGetSpecialsInputPort
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
