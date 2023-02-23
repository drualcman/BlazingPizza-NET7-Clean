namespace BlazingPizza.EFCore.Repositories.DataContext;
internal class BlazingPizzaContext : DbContext
{
	readonly ConnectionStringOptions ConnectionStringOptions;
	public BlazingPizzaContext(IOptions<ConnectionStringOptions> options)
	{
		ConnectionStringOptions = options.Value;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
	{
		optionsBuilder.UseSqlServer(ConnectionStringOptions.BlazingPizzaDb);
	}

	public DbSet<PizzaSpecial> Specials { get; set; }
	public DbSet<Topping> Toppings { get; set; }
	public DbSet<Pizza> Pizzas { get; set; }
	public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

}
