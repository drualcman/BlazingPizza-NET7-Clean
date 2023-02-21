namespace BlazingPizza.BussinesObjects.Agregates;
public class Pizza
{
    readonly List<Topping> ToppingsField;
    public PizzaSpecial Special { get; }
    public int Size { get; private set; }
    public IReadOnlyCollection<Topping> Toppings => ToppingsField;

    public bool HasMaximumToppings => Toppings.Count >= 6;


    public Pizza(PizzaSpecial pizzaSpecial)
    {
        Special = pizzaSpecial;
        Size = (int)PizzaSize.Default;
        ToppingsField = new List<Topping>();
    }

    public void SetSize(int size)
    {
        if(Size <= (int)PizzaSize.Maximum) Size = size;
        else if(Size >= (int)PizzaSize.Minimum) Size = size;
        else throw new ArgumentException($"Tamaño de la pizza no valido");
    }

    public void AddTopping(Topping topping)
    {
        if(ToppingsField.Find(t=> t.Id == topping.Id) == null) 
            ToppingsField.Add(topping);        
    }

    public void RemoveToping(Topping topping) => 
        ToppingsField.Remove(topping);

    public decimal GetBasePrice() => 
        (decimal)Size / (decimal)PizzaSize.Default * Special.BasePrice;

    public decimal GetTotalPrice() =>
        GetBasePrice() + ToppingsField.Sum(t => t.Price);

    public string GetFormattedTotalPrice() =>
        GetTotalPrice().ToString("$#.##");

    public string GetFormattedSizeWithTotalPrice() =>
        $"{Size} cm ({GetFormattedTotalPrice()})";

    public PlaceOrderPizzaDto GetPlaceOrderPizzaDto() => new PlaceOrderPizzaDto
    {
        PizzaSpecialId = Special.Id,
        Size = Size,
        ToppingsIds = Toppings.Select(s => s.Id).ToList(),
    };

    public PlaceOrderPizzaDto PlaceOrderPizzaDto => new PlaceOrderPizzaDto
    {
        PizzaSpecialId = Special.Id,
        Size = Size,
        ToppingsIds = Toppings.Select(s => s.Id).ToList(),
    };

    public static explicit operator PlaceOrderPizzaDto(Pizza pizza) => new PlaceOrderPizzaDto
    {
        PizzaSpecialId = pizza.Special.Id,
        Size = pizza.Size,
        ToppingsIds = pizza.Toppings.Select(t => t.Id).ToList()
    };

    public static explicit operator PizzaDto(Pizza pizza) => new PizzaDto(pizza.Special, pizza.Size, pizza.Toppings);


}
