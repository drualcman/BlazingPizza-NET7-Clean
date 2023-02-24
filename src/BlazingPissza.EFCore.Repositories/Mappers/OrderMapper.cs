namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class OrderMapper
{
    internal static Order ToEFOrder(this PlaceOrderOrderDto order) =>
        new Order
        {
            CreatedTime = DateTime.Now,
            UserId = order.UserId,
            DeliveryAddress = order.DeliveryAddress.ToEFAddress(),
            DeliveryLocation = order.DeliveryLocation.ToEFLatLong(),
            Pizzas = order.Pizzas.Select(p=> p.ToEFPizza()).ToList()
        };

    internal static SharedAgreeates.Order ToOrder(this Order order) => 
        SharedAgreeates.Order.Create(order.Id, order.CreatedTime, order.UserId)
            .AddPizzas(order.Pizzas?.Select(p => p.ToPizza()));
}
