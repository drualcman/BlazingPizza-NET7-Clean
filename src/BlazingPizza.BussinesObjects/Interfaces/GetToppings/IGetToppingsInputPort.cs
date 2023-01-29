namespace BlazingPizza.BussinesObjects.Interfaces.GetToppings;
public interface IGetToppingsInputPort
{
    Task<IReadOnlyCollection<Topping>> GetToppingAsync();
}
