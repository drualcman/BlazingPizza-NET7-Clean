namespace BlazingPizza.OrderTrackerSimulator;
public static class Dependencycontainer
{
    public static IServiceCollection AddOrderStatusNotificatorService(this IServiceCollection services)
    {
        services.AddScoped<IOrderStatusNotificator, OrderStatusNotificatorSimulator>();
        return services;
    }
}
