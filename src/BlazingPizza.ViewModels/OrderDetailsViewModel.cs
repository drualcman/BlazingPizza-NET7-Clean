namespace BlazingPizza.ViewModels;
public class OrderDetailsViewModel : IOrderDetailsViewModel
{
    readonly IOrderDetailsModel Model;

    public OrderDetailsViewModel(IOrderDetailsModel model) => Model = model;

    public GetOrderDto Order {get; private set;}

    public bool InvalidOrder {get; private set;}

    public async Task GetOrderDetailsAsync(int id)
    {
        Order = await Model.GetOrderAsync(id);
        InvalidOrder = Order.Id == 0;
    }
}
