namespace BlazingPizza.ViewModels;
public class MyOrdersViewModel : IMyOrdersViewModel
{
    readonly IMyOrdersModel Model;

    public MyOrdersViewModel(IMyOrdersModel model) => Model = model;

    public IReadOnlyCollection<OrderWithStatusDto> OrdersWithStatus { get; private set; }

    public async Task GetOrderAsync()  => OrdersWithStatus = await Model.GetOrdersAsync();
}
