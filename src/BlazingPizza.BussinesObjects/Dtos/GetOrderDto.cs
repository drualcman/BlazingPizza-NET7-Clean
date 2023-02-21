namespace BlazingPizza.BussinesObjects.Dtos;
public class GetOrderDto
{
    public int Id { get; init; }
    public DateTime CreatedTime { get; init; }
    public string UserId { get; init; }
    public string StatusText { get; init; }
    public bool IdDelivered { get; init; }
    public IReadOnlyCollection<PizzaDto> Pizzas { get; init; }     
    public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());
    public string GetFormatedTotalPrice() => GetTotalPrice().ToString("$ #,###.##");
}
