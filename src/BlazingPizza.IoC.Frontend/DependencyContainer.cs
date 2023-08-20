using Membership.Blazor.Entities.Interfaces;
using WebPush.Blazor;

namespace BlazingPizza.IoC.Frontend;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaFrontendServices(this IServiceCollection services,
        IOptions<EndpointsOptions> endpointsOptions, Action<WebPushNotificationOptions> configurePushNotificationOptions)
    {
        Action<IHttpClientBuilder> httpClientConfigurator = 
            bulder => 
            {
                bulder.AddHttpMessageHandler(service => (DelegatingHandler)service.GetRequiredService<IBearerTokenHander>());
            };

        services.AddValidators();
        services.AddModelsServices();
        services.AddViewModelsServices();
        services.AddBlazingPizzaWebApiGateways(endpointsOptions, httpClientConfigurator);
        services.AddToastService();
        services.AddSweetAlertService();  
        services.AddMapsService();
        services.AddGeolocationService();
        //services.AddDefaultGeocoderService("1b48259b810e48ddb151889f9ea58db0");
        services.AddOrderStatusNotificatorService();
        services.AddPushNotificatoinService(configurePushNotificationOptions);
        return services;
    }
}
