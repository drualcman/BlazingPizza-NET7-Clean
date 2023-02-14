namespace BlazingPizza.BussinesObjects.Agregates;
public class Order : BaseOrder
{
    readonly List<Pizza> PizzasField;
    public Order()
    {
        PizzasField = new();
    }

    public bool HasPizzas => PizzasField.Any();

    public Address DeliveryAddress { get; private set; } = new Address("", "", "", "", "", "", "");
    public LatLong DeliveryLocation { get; private set; } = new LatLong();
    public IReadOnlyCollection<Pizza> Pizzas => PizzasField;

    public Order AddPizza(Pizza pizza)
    {
        PizzasField.Add(pizza);
        return this;
    }

    public void RemovePizza(Pizza pizza) =>
        PizzasField.Remove(pizza);

    public Order SetDeliveryAddress(Address address)
    {
        DeliveryAddress = address;
        return this;
    }

    public void SetDeliveryLocation(LatLong deliveryLocation) =>
        DeliveryLocation = deliveryLocation;

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
