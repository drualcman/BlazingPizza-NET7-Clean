namespace BlazingPizza.IoC.Frontend;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaFrontendServices(this IServiceCollection services,
        IOptions<EndpointsOptions> endpointsOptions, Action<IHttpClientBuilder> httpClientConfigurator = null)
    {
        services.AddModelsServices();
        services.AddViewModelsServices();
        services.AddBlazingPizzaWebApiGateways(endpointsOptions, httpClientConfigurator);
        return services;
    }

    //public static IServiceCollection AddBlazingPizzaDesktopServices(this IServiceCollection services)
    //{
    //    services.AddDesktopModelsServices();
    //    services.AddViewModelsServices();
    //    return services;
    //}
}
