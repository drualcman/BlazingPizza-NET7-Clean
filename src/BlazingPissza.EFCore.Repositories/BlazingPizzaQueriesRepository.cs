namespace BlazingPizza.EFCore.Repositories;
public class BlazingPizzaQueriesRepository : IBlazingPizzaQueriesRepository
{
    readonly BlazingPizzaContext Context;

    public BlazingPizzaQueriesRepository(BlazingPizzaContext context)
    {
        Context = context;
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return (await Context.Orders
            .Include(o => o.Pizzas).ThenInclude(p => p.PizzaSpecial)
            .OrderByDescending(o => o.CreatedTime)
            .ToListAsync())
            .Select(o => GetOrdersDtoFake(o.ToOrder())).ToList();
    }

    private void GetStatus(BussinesObjects.Agregates.Order order, out string statusText, out bool isDelivered)
    {
        const string Preparing = "Preparando";
        const string OutForDelivery = "De camino";
        const string Delivered = "Entregado";

        TimeSpan PreparationDurationTime = TimeSpan.FromSeconds(10);
        TimeSpan DeliveryDurationTime = TimeSpan.FromSeconds(10);

        DateTime dispathTime = order.CreatedTime.Add(PreparationDurationTime);

        if(DateTime.Now < dispathTime) statusText = Preparing;
        else if(DateTime.Now < dispathTime + DeliveryDurationTime) statusText = OutForDelivery;
        else statusText = Delivered;

        isDelivered = statusText == Delivered;
    }

    private GetOrdersDto GetOrdersDtoFake(BussinesObjects.Agregates.Order order)
    {
        string statusText;
        bool isDelivered;
        GetStatus(order, out statusText, out isDelivered);
        return new GetOrdersDto(order.Id, order.CreatedTime, order.UserId, order.Pizzas.Count, order.GetTotalPrice(), statusText, isDelivered);
    }

    public async Task<IReadOnlyCollection<BussinesObjects.Entities.PizzaSpecial>> GetSpecialsAsync()
    {
        return await Context.Specials.Select(s => s.ToPizzaSpecial())
                                     .ToListAsync();
    }

    public async Task<IReadOnlyCollection<BussinesObjects.Entities.Topping>> GetToppingsAsync()
    {
        return await Context.Toppings.Select(t => t.ToTopping())
                                     .ToListAsync();
    }

    public async Task<GetOrderDto> GetOrderAsync(int id) 
    {
        Order order = await Context.Orders
            .Where(o => o.Id == id)
            .Include(o => o.Pizzas).ThenInclude(p => p.PizzaSpecial)
            .Include(o => o.Pizzas).ThenInclude(p=> p.Toppings).ThenInclude(t=> t.Topping)
            .FirstOrDefaultAsync();
        return order == null ? new GetOrderDto() : GetOrderDtoFake(order.ToOrder());
    }
    
    private GetOrderDto GetOrderDtoFake(BussinesObjects.Agregates.Order order)
    {
        string statusText;
        bool isDelivered;
        GetStatus(order, out statusText, out isDelivered);
        return new GetOrderDto
        {
            Id = order.Id,
            CreatedTime = order.CreatedTime,
            UserId = order.UserId,
            Pizzas = order.Pizzas.Select(p=> (PizzaDto)p).ToList(),
            StatusText = statusText,
            IdDelivered= isDelivered
        };
    }
}

