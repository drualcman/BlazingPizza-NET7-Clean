namespace BlazingPizza.ViewModels;

public static class DependencyContainer
{
    public static IServiceCollection AddViewModelsServices(this IServiceCollection services)
    {
        services.AddScoped<ISpecialsViewModel, SpecialsViewModel>();
        services.AddScoped<IIndexViewModel, IndexViewModel>();
        services.AddScoped<IConfigurePizzaDialogViewModel, ConfigurePizzaDialogViewModel>();
        services.AddScoped<ICheckoutViewModel, CheckoutViewModel>();
        return services;
    }
}
