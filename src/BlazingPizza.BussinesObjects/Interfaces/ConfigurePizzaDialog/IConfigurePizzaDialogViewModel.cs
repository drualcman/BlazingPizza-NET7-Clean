namespace BlazingPizza.BussinesObjects.Interfaces.ConfigurePizzaDialog;
public interface IConfigurePizzaDialogViewModel
{
    Pizza Pizza { get; set; }
    int ConfiguredPizzaSize { get; set; }
    IReadOnlyCollection<Topping> Toppings { get; }
    Task GetToppingsAsync();
    void AddToping(Topping topping);
    void RemoveToping(Topping topping);
                                
}
