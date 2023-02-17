namespace BlazingPizza.BussinesObjects.Agregates;
public class Order : BaseOrder
{
    readonly List<Pizza> PizzasField;
    public Order()
    {
        PizzasField = new();
    }

    public Order(int orderId, DateTime createDate, string userId) : this()
    {
        Id = orderId;
        CreatedTime = createDate;
        UserId = userId;
    }

    public static Order Create(int orderId, DateTime createdTime, string userId) 
    {
        Order result = new Order();
        result.Id = orderId;
        result.CreatedTime = createdTime;
        result.UserId = userId;
        return result;
    }

    public bool HasPizzas => PizzasField.Any();

    public Address DeliveryAddress { get; private set; } = new Address("", "", "", "", "", "");
    public LatLong DeliveryLocation { get; private set; } = new LatLong();
    public IReadOnlyCollection<Pizza> Pizzas => PizzasField;

    public Order AddPizza(Pizza pizza)
    {
        PizzasField.Add(pizza);
        return this;
    }

    public Order AddPizzas(IEnumerable<Pizza> pizzas)
    {
        if (pizzas is not null) PizzasField.AddRange(pizzas);
        return this;
    }

    public void RemovePizza(Pizza pizza) =>
        PizzasField.Remove(pizza);

    public Order SetDeliveryAddress(Address address)
    {
        DeliveryAddress = address;
        return this;
    }

    public Order SetDeliveryLocation(LatLong deliveryLocation)
    {
        DeliveryLocation = deliveryLocation;
        return this;
    }

    public decimal GetTotalPrice() =>
        PizzasField.Sum(p => p.GetTotalPrice());

    public string GetFormatedTotalPrice() =>
        GetTotalPrice().ToString("$ #.##");

    public static explicit operator PlaceOrderOrderDto(Order order) => new PlaceOrderOrderDto
    {
        UserId = order.UserId,
        DeliveryAddress = order.DeliveryAddress,
        DeliveryLocation = order.DeliveryLocation,
        Pizzas = order.Pizzas.Select(p => (PlaceOrderPizzaDto)p).ToList()
    };


}
