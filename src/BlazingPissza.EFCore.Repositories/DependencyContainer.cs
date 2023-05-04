namespace BlazingPizza.EFCore.Repositories;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddDbContext<IBlazingPizzaQueriesContext, BlazingPizzaQueriesContext>();
        services.AddDbContext<IBlazingPizzaComandsContext, BlazingPizzaCommandsContext>();
        services.AddScoped<IBlazingPizzaQueriesRepository, BlazingPizzaQueriesRepository>();
        services.AddScoped<IBlazingPizzaCommandsRepository, BlazingPizzaCommandsRepository>();
        return services;
    }
}