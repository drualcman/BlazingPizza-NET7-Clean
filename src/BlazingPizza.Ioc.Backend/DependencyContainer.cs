namespace BlazingPizza.Ioc.Backend;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaBackendServices(this IServiceCollection services)
    {
        services.AddRepositoryServices();
        services.AddUseCasesServices();
        services.AddControllersServices();
        services.AddPresenterServices();
        return services;
    }
}
