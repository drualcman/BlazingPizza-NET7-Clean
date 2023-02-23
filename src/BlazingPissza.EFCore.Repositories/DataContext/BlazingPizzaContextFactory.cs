namespace BlazingPizza.EFCore.Repositories.DataContext;
internal class BlazingPizzaContextFactory : IDesignTimeDbContextFactory<BlazingPizzaContext>
{
    public BlazingPizzaContext CreateDbContext(string[] args) 
    {
        ConnectionStringOptions connectionOptions = new ConnectionStringOptions
        {
            BlazingPizzaDb = "Server=(localdb)\\mssqllocaldb;database=BlazingPizzaDBCA"
        };
        return new BlazingPizzaContext(Options.Create(connectionOptions));
    }
}
