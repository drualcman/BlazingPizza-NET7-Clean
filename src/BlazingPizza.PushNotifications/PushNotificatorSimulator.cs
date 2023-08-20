using BlazingPizza.Backend.BussinesObjects.Interfaces.PushNotifications;
using BlazingPizza.PushNotifications.Options;
using BlazingPizza.Shared.BussinesObjects.ValueObjects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using WebPush.Server;
using WebPush.Server.Models;

namespace BlazingPizza.PushNotifications;

public class PushNotificatorSimulator : IPushNotificator
{
    readonly VapidInfoOptions VapidInfoOptions;
    readonly IServiceScopeFactory ServiceScopeFactory;

    public PushNotificatorSimulator(IOptions<VapidInfoOptions> vapidInfoOptions, IServiceScopeFactory serviceScopeFactory)
    {
        VapidInfoOptions = vapidInfoOptions.Value;
        ServiceScopeFactory = serviceScopeFactory;
    }

    public void StartNotification(int orderId, WebPushSubscrition webPushsubscrition)
    {
        Task.Run(async () =>
        {
            const int PreparationTime = 10000;
            const int DeliveryTime = 90000;

            using AsyncServiceScope scope = ServiceScopeFactory.CreateAsyncScope();
            WebPushService webPushService = scope.ServiceProvider.GetService<WebPushService>();
            ILogger<PushNotificatorSimulator> logger = scope.ServiceProvider.GetRequiredService<ILogger<PushNotificatorSimulator>>();

            WebPushsubscrition subscription = new WebPushsubscrition(
                  webPushsubscrition.Endpoint,
                  webPushsubscrition.P256dh,
                  webPushsubscrition.Auth
                );
            VapidInfo vapidInfo = new VapidInfo(VapidInfoOptions.Subject, VapidInfoOptions.PublicKey, VapidInfoOptions.PrivateKey);

            await Task.Delay(PreparationTime);
            await SendMotification(webPushService, logger, subscription, vapidInfo, "Tu orden ya esta de caminio!", orderId);
            await Task.Delay(DeliveryTime);
            await SendMotification(webPushService, logger, subscription, vapidInfo, "Tu orden ha dido entregada!. Disfrutala!", orderId);

        });
    }

    private async Task SendMotification(WebPushService webPushService, ILogger<PushNotificatorSimulator> logger, WebPushsubscrition subscription, VapidInfo vapidInfo, string message, int orderId)
    {
        var payload = new
        {
            message = message,
            url = $"order/{orderId}"
        };

        string serializePayload = JsonSerializer.Serialize(payload);
        try
        {
            await webPushService.SendNotificationAsync(subscription, serializePayload, vapidInfo, CancellationToken.None);
            logger.LogInformation("*** send '{0}' notification. ***", message);
        }
        catch(Exception ex)
        {
            logger.LogError("Error: {0}", ex.Message);
            throw;
        }
    }
}
