namespace BlazingPizza.WebApi.Endpoints;

internal static class OrUsersders
{
    public static WebApplication UseUsersEndpoints(this WebApplication app)
    {
        app.MapPost("/user/register", async (UserForRegistrationDto userData, IRegisterController controller) =>
        {
            await controller.RegisterAsync(userData);
            return Results.Ok();
        });   
        app.MapPost("/user/login", async (UserCredentialsDto userCredentialsDto, ILoginController controller) =>
            Results.Ok(await controller.LoginAsync(userCredentialsDto)));

        return app;
    }
}
