namespace BlazingPissza.EFCore.Repositories.Mappers;
internal static class EntitiesMapper
{
    public static BlazingPizza.BussinesObjects.Entities.PizzaSpecial ToPizzaSpecial(this PizzaSpecial pizzaSpecial) =>
        new BlazingPizza.BussinesObjects.Entities.PizzaSpecial
        {
            Id = pizzaSpecial.Id,
            Name = pizzaSpecial.Name,
            Description = pizzaSpecial.Description,
            BasePrice = pizzaSpecial.BasePrice,
            ImageUrl = pizzaSpecial.ImageUrl
        };

    public static BlazingPizza.BussinesObjects.Entities.Topping ToTopping(this Topping topping) =>
        new BlazingPizza.BussinesObjects.Entities.Topping
        {
            Id = topping.Id,
            Name = topping.Name,
            Price = topping.Price
        };
}
