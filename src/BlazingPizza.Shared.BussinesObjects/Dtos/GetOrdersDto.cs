using BlazingPizza.Shared.BussinesObjects.Enums;

namespace BlazingPizza.Shared.BussinesObjects.Dtos;
public record class GetOrdersDto(int Id, DateTime CreatedTime, string UserId,
    int PizzasCount, decimal TotalPrice, OrderStatus Status, bool IsDelivered)
{
    public string GetFormatedTotalPrice() => TotalPrice.ToString("$ #,###.##");
}
