namespace BlazingPissza.EFCore.Repositories.DataContext;
public class BlazingPizzaContext : DbContext
{
	public BlazingPizzaContext(DbContextOptions options) : base(options) { }

	public DbSet<PizzaSpecial> Specials { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) 
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
