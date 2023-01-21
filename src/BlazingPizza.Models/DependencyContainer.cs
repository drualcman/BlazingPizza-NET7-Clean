namespace BlazingPizza.Models;

public static class DependencyContainer
{
    public static IServiceCollection AddModelsServices(this IServiceCollection services)
    {
        services.AddScoped<ISpecialsModel, SpecialsModel>();
        return services;
    }
}
