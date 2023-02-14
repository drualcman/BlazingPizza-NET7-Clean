namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class OrderMapper
{
    internal static Order ToEFPizza(this PlaceOrderOrderDto order) =>
        new Order
        {
            CreatedTime = DateTime.Now,
            UserId = order.UserId,
            DeliveryAddress = order.DeliveryAddress.ToEFAddress(),
            DeliveryLocation = order.DeliveryLocation.ToEFLatLong(),
            Pizzas = order.Pizzas.Select(p=> p.ToEFPizza()).ToList()
        };
}
