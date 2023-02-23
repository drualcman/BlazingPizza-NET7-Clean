namespace BlazingPizza.EFCore.Repositories.Interfaces;
internal interface IBlazingPizzaQueriesContext
{
    internal DbSet<PizzaSpecial> Specials { get; set; }
	internal DbSet<Topping> Toppings { get; set; }
	internal DbSet<Order> Orders { get; set; }
}
