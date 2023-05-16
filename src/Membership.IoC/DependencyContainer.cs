namespace Membership.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddCoreMemberShipCoreServices(this IServiceCollection services)
    {
        services.AddUserManagerCoreServices();
        services.AddMemberShipControlleresServices();
        services.AddMembershipPresenters();
        services.AddUserService();
        return services;
    }  
    
    public static IServiceCollection AddMemberShipServices(this IServiceCollection services)
    {
        services.AddCoreMemberShipCoreServices();
        services.AddAspNetIdentityServices();
        services.AddRefreshTokenManagerServices();
        return services;
    }
}