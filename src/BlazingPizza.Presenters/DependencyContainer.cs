using BlazingPizza.Backend.BussinesObjects.Interfaces.GetSpecials;

namespace BlazingPizza.Presenters;

public static class DependencyContainer
{
    public static IServiceCollection AddPresenterServices(this IServiceCollection services)
    {
        services.AddScoped<IGetSpecialsPresenter, GetSpecialsPresenter>();
        return services;
    }
}
