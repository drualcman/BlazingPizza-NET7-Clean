namespace BlazingPizza.BussinesObjects.Interfaces.Specials;

public interface ISpecialsViewModel
{
    IReadOnlyCollection<PizzaSpecial> Specials { get; }
    Task GetSpeiclasAsync();
}
