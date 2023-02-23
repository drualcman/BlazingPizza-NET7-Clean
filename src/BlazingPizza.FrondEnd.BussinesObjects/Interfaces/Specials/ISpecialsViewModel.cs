namespace BlazingPizza.FrondEnd.BussinesObjects.Interfaces.Specials;

public interface ISpecialsViewModel
{
    IReadOnlyCollection<PizzaSpecial> Specials { get; }
    Task GetSpeiclasAsync();
}
