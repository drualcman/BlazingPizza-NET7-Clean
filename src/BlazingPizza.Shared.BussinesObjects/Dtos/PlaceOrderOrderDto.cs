﻿namespace BlazingPizza.Shared.BussinesObjects.Dtos;
public class PlaceOrderOrderDto
{
    public string UserId { get; set; }
    public Address DeliveryAddress { get; set; }
    public LatLong DeliveryLocation { get; set; }
    public List<PlaceOrderPizzaDto> Pizzas { get; set; }
    public WebPushSubscrition Subscription { get; set; }
}
