namespace BlazingPizza.EFCore.Repositories;
public class BlazingPizzaQueriesRepository : IBlazingPizzaQueriesRepository
{
    readonly BlazingPizzaContext Context;

    public BlazingPizzaQueriesRepository(BlazingPizzaContext context)
    {
        Context = context;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public async Task<IReadOnlyCollection<OrderWithStatusDto>> GetOrdersAsync() 
    {
        return await Context.Orders
            .Include(o => o.DeliveryAddress)
            .Include(o => o.DeliveryLocation)
            .Include(o => o.Pizzas).ThenInclude(p => p.PizzaSpecial)
            //.Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
            .OrderByDescending(o => o.CreatedTime)
            .Select(o => new OrderWithStatusDto(o.ToOrder()))
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<BussinesObjects.Entities.PizzaSpecial>> GetSpecialsAsync()
    {           
        return await Context.Specials.Select( s=> s.ToPizzaSpecial())
                                     .ToListAsync();
    }

    public async Task<IReadOnlyCollection<BussinesObjects.Entities.Topping>> GetToppingsAsync()
    {
        return await Context.Toppings.Select(t=> t.ToTopping())
                                     .ToListAsync();
    }
}

