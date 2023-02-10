namespace BlazingPizza.EFCore.Repositories;
public class BlazingPizzaQueriesRepository : IBlazingPizzaQueriesRepository
{
    readonly BlazingPizzaContext Context;

    public BlazingPizzaQueriesRepository(BlazingPizzaContext context)
    {
        Context = context;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public async Task<IReadOnlyCollection<BlazingPizza.BussinesObjects.Entities.PizzaSpecial>> GetSpecialsAsync()
    {           
        return await Context.Specials.Select( s=> s.ToPizzaSpecial())
                                     .ToListAsync();
    }

    public async Task<IReadOnlyCollection<BlazingPizza.BussinesObjects.Entities.Topping>> GetToppingsAsync()
    {
        return await Context.Toppings.Select(t=> t.ToTopping())
                                     .ToListAsync();
    }
}

