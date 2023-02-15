namespace BlazingPizza.BussinesObjects.Dtos;
public class OrderWithStatusDto : BaseOrder
{
    const string Preparing = "Preparando";
    const string OutForDelivery = "De camino";
    const string Delivered = "Entregado";

    public readonly static TimeSpan PreparationDurationTime = TimeSpan.FromSeconds(10);
    public readonly static TimeSpan DeliveryDurationTime = TimeSpan.FromSeconds(10);

    public int PizzasCount { get; set; }
    public decimal TotalPrice { get; set; }
    public string GetFormatedTotalPrice() => TotalPrice.ToString("$ #,###.##");

    public OrderWithStatusDto(Order order)
    {
        Id= order.Id;
        CreatedTime= order.CreatedTime;
        UserId= order.UserId;
        PizzasCount = order.Pizzas.Count;
        TotalPrice = order.GetTotalPrice();
    }

    string StatusTextField;
    public string StatusText
    {
        get 
        {
            DateTime dispathTime = CreatedTime.Add(PreparationDurationTime);
            if(DateTime.Now < dispathTime) StatusTextField = Preparing;
            else if(DateTime.Now < dispathTime + DeliveryDurationTime) StatusTextField = OutForDelivery;
            else StatusTextField = Delivered;
            return StatusTextField;
        }
    }

    public bool IsDelivered => StatusTextField == Delivered;
}
