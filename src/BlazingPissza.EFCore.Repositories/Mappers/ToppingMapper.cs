namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class ToppingMapper
{
    internal static Shared.BussinesObjects.Entities.Topping ToTopping(this Topping topping) =>
        new Shared.BussinesObjects.Entities.Topping
        {
            Id = topping.Id,
            Name = topping.Name,
            Price = topping.Price
        };
}
