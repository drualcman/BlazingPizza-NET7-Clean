namespace BlazingPissza.EFCore.Repositories;
public class BlazingPizzaRepository : IBlazingPizzaRepository
{
    readonly BlazingPizzaContext Context;

    public BlazingPizzaRepository(BlazingPizzaContext context)
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

