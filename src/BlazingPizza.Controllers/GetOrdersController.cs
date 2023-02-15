namespace BlazingPizza.Controllers;
public class GetOrdersController : IGetOrdersController
{
    readonly IGetOrdersInputPort InputPort;

    public GetOrdersController(IGetOrdersInputPort inputPort) => InputPort = inputPort;

    public Task<IReadOnlyCollection<OrderWithStatusDto>> GetOrdersAsync() => InputPort.GetOrdersAsync();
}
