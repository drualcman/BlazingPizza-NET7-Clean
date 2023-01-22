namespace BlazingPizza.Ioc.Backend;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaBackendServices(this IServiceCollection services, string connectionString, string imageBaseUrlName)
    {
        services.AddURepositoryServices(connectionString);
        services.AddUseCasesServices();
        services.AddControllersServices();
        services.AddPresenterServices(imageBaseUrlName);
        return services;
    }
}
