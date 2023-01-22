namespace BlazingPizza.Models;

public static class DependencyContainer
{
    public static IServiceCollection AddModelsServices(this IServiceCollection services)
    {
        services.AddScoped<ISpecialsModel, SpecialsModel>();
        return services;
    } 
    public static IServiceCollection AddDesktopModelsServices(this IServiceCollection services)
    {
        services.AddScoped<ISpecialsModel, DesktopSpecialModel>();
        return services;
    }
}
