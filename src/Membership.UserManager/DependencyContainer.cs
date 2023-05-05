namespace Membership.UserManager;
public static class DependencyContainer
{
    public static IServiceCollection AddUserManagerCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterInputPort, RegisterInteractor>();
        return services;
    }
}