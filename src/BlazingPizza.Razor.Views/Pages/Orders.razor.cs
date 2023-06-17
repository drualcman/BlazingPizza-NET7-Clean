namespace BlazingPizza.Razor.Views.Pages;

[Authorize]
public partial class Orders
{
    [Inject] public IOrdersViewModel ViewModel { get; set; }

    async Task<List<GetOrdersDto>> LoadOrders()
    {
        await ViewModel.GetOrderAsync();
        return ViewModel.Orders.ToList();
    }
}