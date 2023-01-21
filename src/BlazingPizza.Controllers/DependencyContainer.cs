namespace BlazingPizza.Controllers;

public static class DependencyContainer
{
    public static IServiceCollection AddControllersServices(this IServiceCollection services)
    {
        services.AddScoped<IGetSpecialsController, GetSpecialControllers>();
        return services;
    }
}
