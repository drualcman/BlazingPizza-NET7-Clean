namespace BlazingPizza.Shared.BussinesObjects.ValueObjects;

public class WebPushSubscrition
{
    public string Endpoint { get; set; }
    public string P256dh { get; set; }
    public string Auth { get; set; }

    public WebPushSubscrition(string endpoint, string p256dh, string auth)
    {
        Endpoint = endpoint;
        P256dh = p256dh;
        Auth = auth;
    }
}
