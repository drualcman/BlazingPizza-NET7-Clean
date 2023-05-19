using Membership.Entities.Logout;
using Membership.Entities.RefreshToken;
using Membership.Shared.Entities;

namespace BlazingPizza.WebApi.Endpoints;

internal static class OrUsersders
{
    public static WebApplication UseUsersEndpoints(this WebApplication app)
    {
        app.MapPost("/user/register", async (LocalUserForRegistrationDto userData, IRegisterController controller) =>
        {
            await controller.RegisterAsync(userData);
            return Results.Ok();
        });
        app.MapPost("/user/login", async (UserCredentialsDto userCredentialsDto, ILoginController controller, HttpContext context) =>
        {
            context.Response.Headers.Add("Cache-Control", "no-store");
            return Results.Ok(await controller.LoginAsync(userCredentialsDto));
        });
        app.MapPost("/user/regresh-token", async (UserTokensDto userTokens, IRefreshTokenController controller, HttpContext context) =>
        {
            context.Response.Headers.Add("Cache-Control", "no-store");
            return Results.Ok(await controller.RefreshTokenAsync(userTokens));
        }); 
        app.MapPost("/user/logout", async (string refreshToken, ILogoutController controller) =>
        {
            await controller.LogoutAsync(refreshToken);
            return Results.Ok();
        });

        return app;
    }
}
