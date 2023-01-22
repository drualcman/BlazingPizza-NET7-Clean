namespace BlazingPizza.BussinesObjects.Interfaces.ConfigurePizzaDialog;
public interface IConfigurePizzaDialogModel
{                                                                 
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
}
