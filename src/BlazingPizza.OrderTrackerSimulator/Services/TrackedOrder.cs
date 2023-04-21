namespace BlazingPizza.OrderTrackerSimulator.Services;

internal class TrackedOrder
{
    public DateTime CreatedTime { get; }
    public DateTime StartForDelivery { get; set; }
    public LatLong Origin { get; set; }
    public LatLong Destination { get; set; }
    public Action<OrderStatusNotification> Callback { get; set; }
    public double Speed { get; }
    public double TotalDistance { get; }
    public double Degree { get; }

    public System.Timers.Timer Timer { get; }

    public TrackedOrder(LatLong origing, LatLong destination, DateTime createdTime,
        Action<OrderStatusNotification> callback,
        double speed, double totalDistance, double degree, System.Timers.Timer timer)
    {
        CreatedTime = createdTime;
        Origin = origing;
        Destination = destination;
        Callback = callback;
        Speed = speed;
        TotalDistance = totalDistance;
        Degree = degree;
        Timer = timer;
    }
}
