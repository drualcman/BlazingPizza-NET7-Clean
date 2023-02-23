namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class PizzaSpecialMapper
{
    internal static Shared.BussinesObjects.Entities.PizzaSpecial ToPizzaSpecial(this PizzaSpecial pizzaSpecial) =>
        new Shared.BussinesObjects.Entities.PizzaSpecial
        {
            Id = pizzaSpecial.Id,
            Name = pizzaSpecial.Name,
            Description = pizzaSpecial.Description,
            BasePrice = pizzaSpecial.BasePrice,
            ImageUrl = pizzaSpecial.ImageUrl
        };
}
