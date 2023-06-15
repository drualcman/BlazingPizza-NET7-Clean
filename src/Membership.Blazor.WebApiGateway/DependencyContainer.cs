namespace Membership.Blazor.WebApiGateway;
public static class DependencyContainer
{
    public static IServiceCollection AddMembershipWebApiGatewayServices(this IServiceCollection services,
        Action<UserEnpointOptions> userEndpointsSetter)
    {
        services.Configure<UserEnpointOptions>(options => userEndpointsSetter(options));
        services.AddHttpClient(nameof(IUserWebApiGateway));
        services.AddScoped<IUserWebApiGateway, UserWebApiGateway>();
        return services;
    }
}