namespace BlazingPizza.Controllers;
internal sealed class GetToppingsController : IGetToppingsController
{
    readonly IGetToppingsInputPort InputPort;

    public GetToppingsController(IGetToppingsInputPort inputPort) => InputPort = inputPort;

    public Task<IReadOnlyCollection<Topping>> GetToppingAsync() => InputPort.GetToppingAsync();
}
