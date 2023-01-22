namespace BlazingPizza.ViewModels;

public static class DependencyContainer
{
    public static IServiceCollection AddViewModelsServices(this IServiceCollection services)
    {
        services.AddScoped<ISpecialsViewModel, SpecialsViewModel>();
        services.AddScoped<IIndexViewModel, IndexViewModel>();
        return services;
    }
}
