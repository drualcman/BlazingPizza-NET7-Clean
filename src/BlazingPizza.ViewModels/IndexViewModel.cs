namespace BlazingPizza.ViewModels;
public class IndexViewModel : IIndexViewModel
{
    public Pizza ConfiguringPizza { get ; set ; }
    public bool ShowingConfigureDialog  { get ; set ; }

    public Task CancelConfigurePizzaDialog() 
    {
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
        return Task.CompletedTask;
    }

    public Task ConfirmConfigurePizzaDialog()
    {                      
        //TODO: Agregar la pizza a la orden
                    
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;     
        return Task.CompletedTask;
    }

    public Task ShowConfigurePizzaDialog(PizzaSpecial special)
    {                              
        ConfiguringPizza = new Pizza(special);
        ShowingConfigureDialog = true;
        return Task.CompletedTask;
    }
}
