namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class PizzaMapper
{            
     internal static Pizza ToEFPizza(this PlaceOrderPizzaDto pizza) =>
        new Pizza
        {
            PizzaSpecialId= pizza.PizzaSpecialId,
            Size= pizza.Size,
            Toppings = pizza.ToppingsIds
                        .Select(id => new PizzaTopping 
                        { 
                            ToppingId = id 
                        }).ToList()
        };

    internal static Shared.BussinesObjects.Agregates.Pizza ToPizza(this Pizza pizza)
    {
        Shared.BussinesObjects.Agregates.Pizza pizzaAgregate = new Shared.BussinesObjects.Agregates.Pizza(pizza.PizzaSpecial.ToPizzaSpecial());
        pizzaAgregate.SetSize(pizza.Size);
        pizza.Toppings?.ForEach(t => pizzaAgregate.AddTopping(t.Topping.ToTopping()));
        return pizzaAgregate;
    }     
}
