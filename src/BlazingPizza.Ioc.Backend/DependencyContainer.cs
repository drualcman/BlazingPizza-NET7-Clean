using BlazingPizza.PushNotifications.Options;

namespace BlazingPizza.Ioc.Backend;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaBackendServices(this IServiceCollection services,
        Action<VapidInfoOptions> configurePushNotificationOptions)
    {           
        services.AddValidators();
        services.AddRepositoryServices();
        services.AddUseCasesServices();
        services.AddControllersServices();
        services.AddPresenterServices();
        services.AddExceptionHandlers();
        services.AddMemberShipServices();
        services.AddPushNotificatorService(configurePushNotificationOptions);
        return services;
    }
}
