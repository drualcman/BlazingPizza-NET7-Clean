using HttpMessageHandlers;

namespace Membership.Blazor.WebApiGateway;
public static class DependencyContainer
{
    public static IServiceCollection AddMembershipWebApiGatewayServices(this IServiceCollection services,
        Action<UserEnpointOptions> userEndpointsSetter)
    {
        services.AddOptions<UserEnpointOptions>().Configure(userEndpointsSetter);
        services.AddHttpClient<IUserWebApiGateway, UserWebApiGateway>().AddHttpMessageHandler(() => new ExceptionDelegatingHandler());
        return services;
    }
}