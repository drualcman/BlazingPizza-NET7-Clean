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
}
