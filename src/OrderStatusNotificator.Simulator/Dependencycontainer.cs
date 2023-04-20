namespace OrderStatusNotificator.Simulator;
public static class Dependencycontainer
{
    public static IServiceCollection AddOrderStatusNotificator(this IServiceCollection services)
    {
        services.AddScoped<IOrderStatusNotificator, OrderStatusNotificatorSimulator>();
        return services;
    }
}
