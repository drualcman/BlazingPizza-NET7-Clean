using BlazingPizza.Backend.BussinesObjects.Interfaces.GetToppings;

namespace BlazingPizza.WebApi.Endpoints;

public static class Toppings
{
    public static WebApplication UseToppingsEndpoints(this WebApplication app)
    {
        app.MapGet("/toppings", async (IGetToppingsController controller) =>
        {
            IReadOnlyCollection<Topping> result = await controller.GetToppingAsync();
            return Results.Ok(result);
        });
        return app;
    }
}
