namespace BlazingPizza.ViewModels;
internal sealed  class ConfigurePizzaDialogViewModel : IConfigurePizzaDialogViewModel
{
    readonly IConfigurePizzaDialogModel Model;

    public ConfigurePizzaDialogViewModel(IConfigurePizzaDialogModel model) => Model = model;

    public Pizza Pizza { get; set; }
    
    public int ConfiguredPizzaSize { get => Pizza.Size; set => Pizza.SetSize(value);  }

    private IReadOnlyCollection<Topping> ToppingsBK;
    public IReadOnlyCollection<Topping> Toppings 
    { 
        get { return ToppingsBK?.OrderBy(t => t.Name).ToList(); }
        private set { ToppingsBK = value; } 
    }

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
