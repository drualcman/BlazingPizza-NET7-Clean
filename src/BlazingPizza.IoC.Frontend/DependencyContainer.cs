namespace BlazingPizza.IoC.Frontend;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaFrontendServices(this IServiceCollection services,
        IOptions<EndpointsOptions> endpointsOptions, Action<IHttpClientBuilder> httpClientConfigurator = null)
    {
        services.AddValidators();
        services.AddModelsServices();
        services.AddViewModelsServices();
        services.AddBlazingPizzaWebApiGateways(endpointsOptions, httpClientConfigurator);
        services.AddToastService();
        services.AddSweetAlertService();  
        services.AddMapsService();
        services.AddGeolocationService();
        return services;
    }
}
