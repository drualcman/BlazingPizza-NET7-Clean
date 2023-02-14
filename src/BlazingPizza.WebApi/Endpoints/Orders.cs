namespace BlazingPizza.WebApi.Endpoints;

public static class Orders
{
    public static WebApplication UseOrdersEndpoints(this WebApplication app)
    {
        app.MapPost("/placeorder", async (PlaceOrderOrderDto order, IPlaceOrderController controller) =>
        {
            int orderId = await controller.PlaceOrderAsync(order);
            return Results.Ok(orderId);
        });
        return app;
    }
}
