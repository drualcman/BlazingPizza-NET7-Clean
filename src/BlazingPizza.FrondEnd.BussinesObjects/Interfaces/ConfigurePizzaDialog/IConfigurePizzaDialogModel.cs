namespace BlazingPizza.FrondEnd.BussinesObjects.Interfaces.ConfigurePizzaDialog;
public interface IConfigurePizzaDialogModel
{
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
}
