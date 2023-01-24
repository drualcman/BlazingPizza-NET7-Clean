namespace BlazingPizza.ViewModels;
internal class ConfigurePizzaDialogViewModel : IConfigurePizzaDialogViewModel
{
    readonly IConfigurePizzaDialogModel Model;

    public ConfigurePizzaDialogViewModel(IConfigurePizzaDialogModel model) => Model = model;

    public Pizza Pizza { get; set; }

    public IReadOnlyCollection<Topping> Toppings { get; private set; }

    public void AddToping(Topping topping) =>
        Pizza.AddTopping(topping);

    public async Task GetToppingsAsync()
    {
        if (Toppings == null)
            Toppings = await Model.GetToppingsAsync();
    }
    public void RemoveToping(Topping topping) =>
        Pizza.RemoveToping(topping);
}
