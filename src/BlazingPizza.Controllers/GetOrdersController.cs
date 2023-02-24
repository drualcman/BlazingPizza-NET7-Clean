namespace BlazingPizza.Controllers;
internal sealed class GetOrdersController : IGetOrdersController
{
    readonly IGetOrdersInputPort InputPort;

    public GetOrdersController(IGetOrdersInputPort inputPort) => InputPort = inputPort;

    public Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync() => InputPort.GetOrdersAsync();
}
