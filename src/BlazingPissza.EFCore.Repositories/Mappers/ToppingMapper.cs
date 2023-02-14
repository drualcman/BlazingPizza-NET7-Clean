namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class ToppingMapper
{
    internal static BussinesObjects.Entities.Topping ToTopping(this Topping topping) =>
        new BussinesObjects.Entities.Topping
        {
            Id = topping.Id,
            Name = topping.Name,
            Price = topping.Price
        };
}
