namespace BlazingPizza.ViewModels;
public class OrdersViewModel : IOrdersViewModel
{
    readonly IOrdersModel Model;

    public OrdersViewModel(IOrdersModel model) => Model = model;

    public IReadOnlyCollection<GetOrdersDto> OrdersWithStatus { get; private set; }

    public async Task GetOrderAsync()  => OrdersWithStatus = await Model.GetOrdersAsync();
}
