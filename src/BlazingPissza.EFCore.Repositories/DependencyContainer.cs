namespace BlazingPizza.EFCore.Repositories;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {           
        services.AddDbContext<BlazingPizzaContext>();
        services.AddScoped<IBlazingPizzaQueriesRepository, BlazingPizzaQueriesRepository>();
        services.AddScoped<IBlazingPizzaCommandsRepository, BlazingPizzaCommandsRepository>();
        return services;
    }
}