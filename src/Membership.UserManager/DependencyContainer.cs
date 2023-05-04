namespace Membership.UserManager;
public static class DependencyContainer
{
    public static IServiceCollection AddMemberShipCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterInputPort, RegisterInteractor>();
        return services;
    }
}