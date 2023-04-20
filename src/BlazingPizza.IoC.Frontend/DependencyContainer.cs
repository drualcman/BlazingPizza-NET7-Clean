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
        services.AddDefaultGeocoderService("1b48259b810e48ddb151889f9ea58db0");
        services.AddOrderStatusNotificator();
        return services;
    }
}
