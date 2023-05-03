namespace BlazingPizza.Ioc.Backend;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaBackendServices(this IServiceCollection services)
    {           
        services.AddUserService();
        services.AddValidators();
        services.AddRepositoryServices();
        services.AddUseCasesServices();
        services.AddControllersServices();
        services.AddPresenterServices();
        services.AddExceptionHandlers();
        return services;
    }
}
