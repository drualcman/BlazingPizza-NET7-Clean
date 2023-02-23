namespace BlazingPizza.EFCore.Repositories.DataContext;
internal class BlazingPizzaCommandsContext : BlazingPizzaContext, IBlazingPizzaComandsContext
{
    public BlazingPizzaCommandsContext(IOptions<ConnectionStringOptions> options) : base(options)
    {
    }

    public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
}
