namespace BlazingPizza.EFCore.Repositories.Interfaces;
internal interface IBlazingPizzaComandsContext
{
	internal DbSet<Order> Orders { get; set; }
	internal Task<int> SaveChangesAsync();
}
