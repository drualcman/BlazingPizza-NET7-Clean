namespace BlazingPizza.EFCore.Repositories;
internal sealed class BlazingPizzaQueriesRepository : IBlazingPizzaQueriesRepository
{
    readonly IBlazingPizzaQueriesContext Context;

    public BlazingPizzaQueriesRepository(IBlazingPizzaQueriesContext context)
    {
        Context = context;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync(string userId)
    {
        return (await Context.Orders
            .Where(o => o.UserId == userId)
            .Include(o => o.Pizzas).ThenInclude(p => p.PizzaSpecial)
            .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
            .OrderByDescending(o => o.CreatedTime)
            .ToListAsync())
            .Select(o => GetOrdersDtoFake(o.ToOrder())).ToList();
    }

    private void GetStatus(SharedAgreeates.Order order, out OrderStatus status, out bool isDelivered)
    {
        TimeSpan PreparationDurationTime = TimeSpan.FromSeconds(10);
        TimeSpan DeliveryDurationTime = TimeSpan.FromMinutes(1.5);

        DateTime dispathTime = order.CreatedTime.Add(PreparationDurationTime);

        if(DateTime.Now < dispathTime) status = OrderStatus.Preparing;
        else if(DateTime.Now < dispathTime + DeliveryDurationTime) status = OrderStatus.OutForDelivery;
        else status = OrderStatus.Delivered;

        isDelivered = status == OrderStatus.Delivered;
    }

    private GetOrdersDto GetOrdersDtoFake(SharedAgreeates.Order order)
    {
        OrderStatus status;
        bool isDelivered;
        GetStatus(order, out status, out isDelivered); 
        return new GetOrdersDto(order.Id, order.CreatedTime, order.UserId, order.Pizzas.Count, order.GetTotalPrice(), status, isDelivered);
    }

    public async Task<IReadOnlyCollection<SharedEntities.PizzaSpecial>> GetSpecialsAsync()
    {
        return await Context.Specials.Select(s => s.ToPizzaSpecial())
                                     .ToListAsync();
    }

    public async Task<IReadOnlyCollection<SharedEntities.Topping>> GetToppingsAsync()
    {
        return await Context.Toppings.Select(t => t.ToTopping())
                                     .ToListAsync();
    }

    public async Task<GetOrderDto> GetOrderAsync(int id, string userId)
    {
        Order order = await Context.Orders
            .Where(o => o.Id == id)
            .Where(o => o.UserId == userId)
            .Include(o => o.Pizzas).ThenInclude(p => p.PizzaSpecial)
            .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
            .FirstOrDefaultAsync();
        return order == null ? new GetOrderDto() : GetOrderDtoFake(order.ToOrder());
    }

    private GetOrderDto GetOrderDtoFake(SharedAgreeates.Order order)
    {
        OrderStatus status;
        bool isDelivered;
        GetStatus(order, out status, out isDelivered);
        return new GetOrderDto
        {
            Id = order.Id,
            CreatedTime = order.CreatedTime,
            UserId = order.UserId,
            Pizzas = order.Pizzas.Select(p => (PizzaDto)p).ToList(),
            Status = status,
            IdDelivered = isDelivered,
            DeliveryLocation = order.DeliveryLocation
        };
    }
}

