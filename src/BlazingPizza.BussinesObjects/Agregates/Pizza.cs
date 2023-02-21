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

    public Pizza SetSize(int size)
    {
        if(Size <= (int)PizzaSize.Maximum) Size = size;
        else if(Size >= (int)PizzaSize.Minimum) Size = size;
        else throw new ArgumentException($"Tamaño de la pizza no valido");
        return this;
    }

    public void AddTopping(Topping topping)
    {
        if(ToppingsField.Find(t=> t.Id == topping.Id) == null) 
            ToppingsField.Add(topping);        
    }   
    public Pizza AddToppings(IEnumerable<Topping> toppings)
    {   
        if(toppings is not null)
            ToppingsField.AddRange(toppings);        
        return this;
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

    public static implicit operator Pizza(PizzaDto pizza)
    {
        Pizza newPizza = new Pizza(pizza.Special);
        newPizza.SetSize(pizza.Size);
        newPizza.AddToppings(pizza.Toppings);
        return newPizza;
    }


}
