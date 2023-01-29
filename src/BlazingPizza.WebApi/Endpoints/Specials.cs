namespace BlazingPizza.WebApi.Endpoints;

public static class Specials
{
    public static WebApplication UseSpecialsEndpoints(this WebApplication app)
    {
        app.MapGet("/specials", async (IGetSpecialsController controller) =>
        {
            IReadOnlyCollection<PizzaSpecial> result = await controller.GetSpecialsAsync();
            return Results.Ok(result);
        });
        return app;
    }
}
