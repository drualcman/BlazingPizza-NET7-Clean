namespace BlazingPizza.EFCore.Repositories;
internal sealed class BlazingPizzaCommandsRepository : IBlazingPizzaCommandsRepository
{
    readonly IBlazingPizzaComandsContext Context;

    public BlazingPizzaCommandsRepository(IBlazingPizzaComandsContext context)
    {
        Context = context;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto order)
    {
        Order Order = order.ToEFOrder();
        Context.Orders.Add(Order);
        await Context.SaveChangesAsync();
        return Order.Id;
    }
}

