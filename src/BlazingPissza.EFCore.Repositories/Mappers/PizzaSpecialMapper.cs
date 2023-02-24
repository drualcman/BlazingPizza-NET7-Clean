namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class PizzaSpecialMapper
{
    internal static SharedEntities.PizzaSpecial ToPizzaSpecial(this PizzaSpecial pizzaSpecial) =>
        new SharedEntities.PizzaSpecial
        {
            Id = pizzaSpecial.Id,
            Name = pizzaSpecial.Name,
            Description = pizzaSpecial.Description,
            BasePrice = pizzaSpecial.BasePrice,
            ImageUrl = pizzaSpecial.ImageUrl
        };
}
