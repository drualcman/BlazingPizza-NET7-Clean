namespace BlazingPissza.EFCore.Repositories;

public static class DependencyContainer
{
    public static IServiceCollection AddURepositoryServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BlazingPizzaContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IBlazingPizzaRepository, BlazingPizzaRepository>();
        return services;
    }
}