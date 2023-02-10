namespace BlazingPizza.EFCore.Repositories;
public class BlazingPizzaCommandsRepository : IBlazingPizzaCommandsRepository
{
    readonly BlazingPizzaContext Context;

    public BlazingPizzaCommandsRepository(BlazingPizzaContext context)
    {
        Context = context;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public Task<int> PlaceOrderAsync(PlaceOrderOrderDto order)
    {
        throw new NotImplementedException();
    }
}

