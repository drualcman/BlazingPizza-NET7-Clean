namespace BlazingPizza.EFCore.Repositories;
public class BlazingPizzaCommandsRepository : IBlazingPizzaCommandsRepository
{
    readonly BlazingPizzaContext Context;

    public BlazingPizzaCommandsRepository(BlazingPizzaContext context)
    {
        Context = context;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto order)
    {
        Order Order = order.ToEFPizza();
        Context.Orders.Add(Order);
        await Context.SaveChangesAsync();
        return Order.Id;
    }
}

