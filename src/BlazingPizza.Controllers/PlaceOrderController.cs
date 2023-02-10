namespace BlazingPizza.Controllers;
public class PlaceOrderController : IPlaceOrderController
{
    readonly IPlaceOrderInputPort InputPort;

    public PlaceOrderController(IPlaceOrderInputPort inputPort) => InputPort = inputPort;

    public Task<int> PlaceOrderAsync(PlaceOrderOrderDto order) => InputPort.PlaceOrderAsync(order);
}
