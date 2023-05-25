namespace Membership.Controllers;
public static class DependencyContainer
{
    public static IServiceCollection AddMemberShipControlleresServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterController, RegisterController>();
        services.AddScoped<IExternalRegisterController, ExternalRegisterController>();
        services.AddScoped<ILoginController, LoginController>();
        services.AddScoped<IRefreshTokenController, RefreshTokenController>();
        services.AddScoped<ILogoutController, LogoutController>();
        return services;
    }
}