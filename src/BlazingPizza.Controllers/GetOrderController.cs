namespace BlazingPizza.Controllers;
internal sealed class GetOrderController : IGetOrderController
{
    readonly IGetOrderInputPort InputPort;

    public GetOrderController(IGetOrderInputPort inputPort) => InputPort = inputPort;

    public Task<GetOrderDto> GetOrderAsync(int id) => InputPort.GetOrderAsync(id);
}
