using BlazingPizza.Backend.BussinesObjects.Interfaces.PushNotifications;
using BlazingPizza.PushNotifications;
using BlazingPizza.PushNotifications.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddPushNotificatorService(this IServiceCollection services,
        Action<VapidInfoOptions> configurePushNotificationOptions)

    {
        services.AddOptions<VapidInfoOptions>().Configure(configurePushNotificationOptions);
        services.AddScoped<IPushNotificator, PushNotificatorSimulator>();
        services.AddWebPushService();
        return services;
    }
}
