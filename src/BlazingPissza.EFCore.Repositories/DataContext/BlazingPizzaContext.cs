namespace BlazingPizza.EFCore.Repositories.DataContext;
public class BlazingPizzaContext : DbContext
{
	public BlazingPizzaContext(DbContextOptions options) : base(options) { }

	public DbSet<EFEntities.PizzaSpecial> Specials { get; set; }
	public DbSet<EFEntities.Topping> Toppings { get; set; }
	public DbSet<EFEntities.Pizza> Pizzas { get; set; }
	public DbSet<EFEntities.Order> Orders { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) 
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
