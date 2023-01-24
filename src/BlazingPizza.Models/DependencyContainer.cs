namespace BlazingPizza.Models;

public static class DependencyContainer
{
    public static IServiceCollection AddModelsServices(this IServiceCollection services)
    {
        services.AddScoped<ISpecialsModel, SpecialsModel>();
        services.AddScoped<IConfigurePizzaDialogModel, ConfigurePizzaDialogModel>();
        return services;
    } 
    public static IServiceCollection AddDesktopModelsServices(this IServiceCollection services)
    {
        services.AddScoped<ISpecialsModel, DesktopSpecialModel>();
        services.AddScoped<IConfigurePizzaDialogModel, ConfigurePizzaDialogModel>();
        return services;
    }
}
