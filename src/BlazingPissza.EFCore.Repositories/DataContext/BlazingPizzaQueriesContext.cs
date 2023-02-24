namespace BlazingPizza.EFCore.Repositories.DataContext;
internal sealed class BlazingPizzaQueriesContext : BlazingPizzaContext, IBlazingPizzaQueriesContext
{
    public BlazingPizzaQueriesContext(IOptions<ConnectionStringOptions> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
}
