namespace BlazingPizza.BussinesObjects.Interfaces.Specials;

public interface ISpecialsModel
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
