namespace BlazingPizza.BussinesObjects.Interfaces.ConfigurePizzaDialog;
public interface IConfigurePizzaDialogViewModel
{
    IReadOnlyCollection<Topping> Toppings { get; }
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
}
