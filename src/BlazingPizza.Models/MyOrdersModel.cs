namespace BlazingPizza.Models;
public class MyOrdersModel : IMyOrdersModel
{
    readonly IBlazingPizzaWebApiGateway GateWay;

    public MyOrdersModel(IBlazingPizzaWebApiGateway gateWay) => GateWay = gateWay;

    public Task<IReadOnlyCollection<OrderWithStatusDto>> GetOrdersAsync() => GateWay.GetOrdersAsync();
}
