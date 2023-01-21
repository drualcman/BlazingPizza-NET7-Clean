namespace BlazingPizza.IoC.Frontend;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaFrontendServices(this IServiceCollection services)
    {
        services.AddModelsServices();
        services.AddViewModelsServices();
        return services;
    }
}
