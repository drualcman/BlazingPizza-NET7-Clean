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
}
