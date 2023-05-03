namespace Membership.UserService;
public static class DependencyContainer
{
    public static IServiceCollection AddUserService(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.TryAddSingleton<IUserService, UserService>();
        return services;
    }
}