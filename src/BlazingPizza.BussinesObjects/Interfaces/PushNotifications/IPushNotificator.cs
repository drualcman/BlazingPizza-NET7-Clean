namespace BlazingPizza.Backend.BussinesObjects.Interfaces.PushNotifications;
public interface IPushNotificator
{
    public void StartNotification(int orderId, WebPushSubscrition webPushsubscrition);
}
