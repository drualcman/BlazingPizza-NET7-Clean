namespace Membership.Presenters;
public static class DependencyContainer
{
    public static IServiceCollection AddMembershipPresenters(this IServiceCollection services)
    {
        services.AddScoped<ILoginPresenter, LoginPresenter>();
        return services;
    }
}