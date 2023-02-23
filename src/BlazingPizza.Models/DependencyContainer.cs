namespace BlazingPizza.Models;

public static class DependencyContainer
{
    public static IServiceCollection AddModelsServices(this IServiceCollection services)
    {
        services.AddScoped<ISpecialsModel, SpecialsModel>();
        services.AddScoped<IOrderStateService, OrderStateService>();
        services.AddScoped<IConfigurePizzaDialogModel, ConfigurePizzaDialogModel>();
        services.AddScoped<ICheckoutModel, CheckoutModel>();
        services.AddScoped<IOrdersModel, OrdersModel>();
        services.AddScoped<IOrderDetailsModel, OrderDetailsModel>();
        return services;
    } 

    //public static IServiceCollection AddDesktopModelsServices(this IServiceCollection services)
    //{
    //    services.AddScoped<ISpecialsModel, DesktopSpecialModel>();
    //    services.AddScoped<IConfigurePizzaDialogModel, ConfigurePizzaDialogModel>();
    //    return services;
    //}
}
