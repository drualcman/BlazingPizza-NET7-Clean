namespace BlazingPizza.Shared.BussinesObjects.ValueObjects;
public class OrderStatusNotification
{
    public LatLong CurrentPosition { get; set; }
    public double CurrentDistance { get; set; }
    public OrderStatus Status { get; set; }

    public OrderStatusNotification(LatLong currentPosition, double currentDistance, OrderStatus status)
    {
        CurrentPosition = currentPosition;
        CurrentDistance = currentDistance;
        Status = status;
    }
}
