using BlazingPizza.Backend.BussinesObjects.Interfaces.Common;

namespace BlazingPizza.EFCore.Repositories;
internal class BlazingPizzaCommandsRepository : IBlazingPizzaCommandsRepository
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

