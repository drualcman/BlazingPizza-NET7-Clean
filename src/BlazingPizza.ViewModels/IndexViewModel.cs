namespace BlazingPizza.ViewModels;
public class IndexViewModel : IIndexViewModel
{
    readonly IOrderStateService OrderService;

    public IndexViewModel(IOrderStateService orderService) => OrderService = orderService;

    public Pizza ConfiguringPizza { get ; set ; }
    public bool ShowingConfigureDialog  { get ; set ; }

    public Task CancelConfigurePizzaDialog() =>
        ResetPizza();

    public async Task ConfirmConfigurePizzaDialog()
    {                      
        OrderService.Order.AddPizza(ConfiguringPizza);
        await ResetPizza();
    }

    public Task ShowConfigurePizzaDialog(PizzaSpecial special)
    {                              
        ConfiguringPizza = new Pizza(special);
        ShowingConfigureDialog = true;
        return Task.CompletedTask;
    }

    Task ResetPizza()
    {                         
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;  
        return Task.CompletedTask;
    }
}
