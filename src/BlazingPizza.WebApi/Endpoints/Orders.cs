﻿namespace BlazingPizza.WebApi.Endpoints;

internal static class Orders
{
    public static WebApplication UseOrdersEndpoints(this WebApplication app)
    {
        app.MapPost("/placeorder", async (PlaceOrderOrderDto order, IPlaceOrderController controller) =>
        {
            int orderId = await controller.PlaceOrderAsync(order);
            return Results.Ok(orderId);
        });
        app.MapGet("/getorders", async (IGetOrdersController controller) => Results.Ok(await controller.GetOrdersAsync()));
        app.MapGet("/getorder/{id}", async (int id, IGetOrderController controller) => Results.Ok(await controller.GetOrderAsync(id)));
        return app;
    }
}
