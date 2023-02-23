namespace BlazingPizza.FrondEnd.BussinesObjects.ValueObjects.Options;
public class EndpointsOptions
{
    public const string SectionKey = "Endpoints";
    public string WebApiBaseAddress { get; set; }
    public string Specials { get; set; } = nameof(Specials);
    public string Toppings { get; set; } = nameof(Toppings);
    public string PlaceOrder { get; set; } = nameof(PlaceOrder);
    public string GetOrders { get; set; } = nameof(GetOrders);
    public string GetOrder { get; set; } = nameof(GetOrder);
}
