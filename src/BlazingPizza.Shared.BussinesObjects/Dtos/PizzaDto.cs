using BlazingPizza.Shared.BussinesObjects.Entities;
using BlazingPizza.Shared.BussinesObjects.Enums;

namespace BlazingPizza.Shared.BussinesObjects.Dtos;
public record class PizzaDto(PizzaSpecial Special, int Size, IReadOnlyCollection<Topping> Toppings)
{
    public decimal GetBasePrice() => Size / (decimal)PizzaSize.Default * Special.BasePrice;
    public decimal GetTotalPrice() => GetBasePrice() + Toppings.Sum(t => t.Price);
    public string GetFormattedTotalPrice() => GetTotalPrice().ToString("$ #,###.##");
}
