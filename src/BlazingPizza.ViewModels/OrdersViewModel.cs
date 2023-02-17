namespace BlazingPizza.ViewModels;
public class OrdersViewModel : IOrdersViewModel
{
    readonly IOrdersModel Model;

    public OrdersViewModel(IOrdersModel model) => Model = model;

    public IReadOnlyCollection<GetOrdersDto> Orders { get; private set; }

    public async Task GetOrderAsync()  => Orders = await Model.GetOrdersAsync();
}
