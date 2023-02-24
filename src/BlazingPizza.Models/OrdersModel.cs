namespace BlazingPizza.Models;
internal sealed class OrdersModel : IOrdersModel
{
    readonly IBlazingPizzaWebApiGateway GateWay;

    public OrdersModel(IBlazingPizzaWebApiGateway gateWay) => GateWay = gateWay;

    public Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync() => GateWay.GetOrdersAsync();
}
