namespace Membership.Blazor.UI;
public static class DependencyContainer
{
    public static IServiceCollection AddMembershipAuthenticationServices(this IServiceCollection services)
    {
        services.AddAuthorizationCore();
        services.AddScoped<JWTAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());
        services.AddScoped<IAuthenticationStateProvider>(provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());
        return services;
    }
}