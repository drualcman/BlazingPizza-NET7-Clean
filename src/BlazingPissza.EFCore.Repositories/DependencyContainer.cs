namespace BlazingPizza.EFCore.Repositories;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BlazingPizzaContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IBlazingPizzaQueriesRepository, BlazingPizzaQueriesRepository>();
        services.AddScoped<IBlazingPizzaCommandsRepository, BlazingPizzaCommandsRepository>();
        return services;
    }
}