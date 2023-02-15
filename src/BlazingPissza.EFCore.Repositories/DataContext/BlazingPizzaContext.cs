namespace BlazingPizza.EFCore.Repositories.DataContext;
public class BlazingPizzaContext : DbContext
{
	public BlazingPizzaContext(DbContextOptions options) : base(options) { }

	public DbSet<PizzaSpecial> Specials { get; set; }
	public DbSet<Topping> Toppings { get; set; }
	public DbSet<Pizza> Pizzas { get; set; }
	public DbSet<Order> Orders { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) 
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
