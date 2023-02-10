namespace BlazingPizza.BussinesObjects.Interfaces.Common;
public interface IBlazingPizzaWebApiGateway
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();   
    Task<int> PlaceOrderAsync(Order order);
}
