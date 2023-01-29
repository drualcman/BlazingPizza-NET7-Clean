namespace BlazingPizza.BussinesObjects.Interfaces.GetToppings;
public interface IGetToppingsController
{
    Task<IReadOnlyCollection<Topping>> GetToppingAsync();
}
