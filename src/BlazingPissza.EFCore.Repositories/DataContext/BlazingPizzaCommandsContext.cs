namespace BlazingPizza.EFCore.Repositories.DataContext;
internal sealed class BlazingPizzaCommandsContext : BlazingPizzaContext, IBlazingPizzaComandsContext
{
    public BlazingPizzaCommandsContext(IOptions<ConnectionStringOptions> options) : base(options)
    {
    }

    public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
}
