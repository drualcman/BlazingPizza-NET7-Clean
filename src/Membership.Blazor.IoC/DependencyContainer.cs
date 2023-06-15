namespace Membership.Blazor.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddMembershipWebBlazorServices(this IServiceCollection services,
        Action<UserEnpointOptions> userEndpointsSetter)
    {
        services.AddMembershipWebApiGatewayServices(userEndpointsSetter);
        return services;
    }
}