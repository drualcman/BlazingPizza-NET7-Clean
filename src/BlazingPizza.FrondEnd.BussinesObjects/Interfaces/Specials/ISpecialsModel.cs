namespace BlazingPizza.FrondEnd.BussinesObjects.Interfaces.Specials;

public interface ISpecialsModel
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
