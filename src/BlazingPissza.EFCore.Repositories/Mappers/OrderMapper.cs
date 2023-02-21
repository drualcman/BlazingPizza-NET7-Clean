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

    internal static BussinesObjects.Agregates.Order ToOrder(this Order order) => 
        BussinesObjects.Agregates.Order.Create(order.Id, order.CreatedTime, order.UserId)
            .AddPizzas(order.Pizzas?.Select(p => p.ToPizza()));
}
