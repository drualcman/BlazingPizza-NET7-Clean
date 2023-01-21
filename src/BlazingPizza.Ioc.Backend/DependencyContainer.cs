namespace BlazingPizza.Ioc.Backend;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaBackendServices(this IServiceCollection services, string connectionString)
    {
        services.AddURepositoryServices(connectionString);
        services.AddUseCasesServices();
        services.AddControllersServices();
        return services;
    }
}
