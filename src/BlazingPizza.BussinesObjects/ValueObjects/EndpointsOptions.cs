namespace BlazingPizza.BussinesObjects.ValueObjects;
public record struct EndpointsOptions(string WebApiBaseAddress, string Specials, string Toppings, 
    string PlaceOrder, string GetOrders, string GetOrder);
