namespace BlazingPissza.EFCore.Repositories.DataContext;
internal class BlazingPizzaContextFactory : IDesignTimeDbContextFactory<BlazingPizzaContext>
{
    public BlazingPizzaContext CreateDbContext(string[] args) 
    {
        DbContextOptionsBuilder options = new DbContextOptionsBuilder<BlazingPizzaContext>();
        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=BlazingPizzaDBCA");
        return new BlazingPizzaContext(options.Options);
    }
}
