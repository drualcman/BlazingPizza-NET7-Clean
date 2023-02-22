namespace BlazingPizza.Ioc.Backend;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaBackendServices(this IServiceCollection services, string connectionString)
    {
        services.AddRepositoryServices(connectionString);
        services.AddUseCasesServices();
        services.AddControllersServices();
        services.AddPresenterServices();
        return services;
    }
}
