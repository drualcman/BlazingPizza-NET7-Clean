namespace Membership.UserService;
public static class DependencyContainer
{
    public static IServiceCollection AddUserService(this IServiceCollection services)
    {
        services.AddSingleton<IUserService, UserService>();
        return services;
    }
}