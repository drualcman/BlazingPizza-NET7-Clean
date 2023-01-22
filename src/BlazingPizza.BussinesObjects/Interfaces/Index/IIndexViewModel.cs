namespace BlazingPizza.BussinesObjects.Interfaces.Index;
public interface IIndexViewModel
{
    Pizza ConfiguringPizza { get; set; }
    bool ShowingConfigureDialog { get; set; }
    Task ShowConfigurePizzaDialog(PizzaSpecial special);
    Task CancelConfigurePizzaDialog();
    Task ConfirmConfigurePizzaDialog();
}
