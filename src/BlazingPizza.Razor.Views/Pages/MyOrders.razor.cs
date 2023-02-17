using BlazingPizza.BussinesObjects.Interfaces.MyOrders;

namespace BlazingPizza.Razor.Views.Pages;

public partial class MyOrders
{
    [Inject] public IMyOrdersViewModel ViewModel { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        await ViewModel.GetOrderAsync();
    }
}