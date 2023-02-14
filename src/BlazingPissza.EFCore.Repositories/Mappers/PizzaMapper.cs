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
}
