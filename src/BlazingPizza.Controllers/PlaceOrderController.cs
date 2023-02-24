namespace BlazingPizza.Controllers;
internal sealed class PlaceOrderController : IPlaceOrderController
{
    readonly IPlaceOrderInputPort InputPort;

    public PlaceOrderController(IPlaceOrderInputPort inputPort) => InputPort = inputPort;

    public Task<int> PlaceOrderAsync(PlaceOrderOrderDto order) => InputPort.PlaceOrderAsync(order);
}
