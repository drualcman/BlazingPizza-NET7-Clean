namespace BlazingPizza.BussinesObjects.Entities;

public class PizzaSpecial
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal BasePrice { get; set; }
    public string ImageUrl { get; set; }
    public string GetFormattedPrice() => 
        BasePrice.ToString("$#.##");
}
