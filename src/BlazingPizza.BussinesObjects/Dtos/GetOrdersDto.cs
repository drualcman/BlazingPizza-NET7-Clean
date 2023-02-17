namespace BlazingPizza.BussinesObjects.Dtos;
public record class GetOrdersDto(int Id, DateTime CreatedTime, string UserId,
    int PizzasCount, decimal TotalPrice, string StatusText, bool IsDelivered)
{ 
    public string GetFormatedTotalPrice() => TotalPrice.ToString("$ #,###.##");
}
